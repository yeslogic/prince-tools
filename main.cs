// Copyright (C) 2012 YesLogic Pty. Ltd.
// All rights reserved.

using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
 
public class GUI : Form
{
    private StatusStrip statusStrip;
    private delegate void AsyncOpenFile(String s);
    private AsyncOpenFile asyncOpenFile;
    private OpenFileDialog openDlg;
    private SaveFileDialog saveDlg;
    private ToolStripMenuItem goItem;
    private TreeView tv;
    private ListView lv;

    [STAThreadAttribute]
    static public void Main ()
    {
	Application.EnableVisualStyles();
	Application.Run(new GUI());
    }

    public GUI()
    {
	this.Text = "Prince";
	
	// Delegate used by drag and drop
	asyncOpenFile = new AsyncOpenFile(this.OpenFile);

	// Accept files dropped from Explorer
	this.AllowDrop = true;
	this.DragEnter += new DragEventHandler(Form_DragEnter);
	this.DragDrop += new DragEventHandler(Form_DragDrop);
	
	// Open file dialog
	openDlg = new OpenFileDialog();
	openDlg.Multiselect = true;
	openDlg.Filter = 
	    "All web content|*.html;*.htm;*.svg;*.xht;*.xhtml;*.xml;*.css;*.js|"+
	    "Documents (HTML, XML, SVG)|*.html;*.htm;*.svg;*.xht;*.xhtml;*.xml|"+
	    "Style sheets (CSS)|*.css|"+
	    "Scripts (*.js)|*.js|"+
	    "All files (*.*)|*.*";
	
	// Save file dialog
	saveDlg = new SaveFileDialog();
	saveDlg.OverwritePrompt = false;
	saveDlg.DefaultExt = "pdf";
	saveDlg.Filter =
	    "PDF files|*.pdf|"+
	    "All files (*.*)|*.*";
	
	// TreeView for files
	tv = new TreeView();
	tv.Dock = DockStyle.Fill;
	tv.ShowNodeToolTips = true;
	tv.AllowDrop = true;
	tv.Nodes.Add("Documents");
	tv.Nodes.Add("Style sheets");
	tv.Nodes.Add("Scripts");
	tv.Nodes[0].NodeFont = new Font(tv.Font, FontStyle.Bold);
	tv.Nodes[1].NodeFont = new Font(tv.Font, FontStyle.Bold);
	tv.Nodes[2].NodeFont = new Font(tv.Font, FontStyle.Bold);
	tv.KeyDown += new KeyEventHandler(TreeView_KeyDown);
	tv.ItemDrag += new ItemDragEventHandler(TreeView_ItemDrag);
	tv.DragEnter += new DragEventHandler(TreeView_DragEnter);
	tv.DragDrop += new DragEventHandler(TreeView_DragDrop);

	// ListView for output log
	lv = new ListView();
	lv.Dock = DockStyle.Fill;
	lv.View = View.Details;
	lv.Columns.Add("Status", -2);
	lv.Columns.Add("Location", -2);
	lv.Columns.Add("Message", -2);
	
	// Split
	SplitContainer split = new SplitContainer();
	split.Dock = DockStyle.Fill;
	split.FixedPanel = FixedPanel.Panel2;
	split.Orientation = Orientation.Horizontal;
	split.Panel1.Controls.Add(tv);
	split.Panel2.Controls.Add(lv);

	this.Controls.Add(split);

	setupMenu();
	setupStatusStrip();
    }

    private void setupMenu()
    {
	MenuStrip ms = new MenuStrip();
	ms.Dock = DockStyle.Top;

	// File menu
	ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
	ms.Items.Add(fileMenu);

	ToolStripMenuItem openItem = new ToolStripMenuItem("&Open...", null,
	    new EventHandler(Menu_Open), Keys.Control | Keys.O);
	
	ToolStripMenuItem exitItem = new ToolStripMenuItem("E&xit", null,
	    new EventHandler(Menu_Exit));

	fileMenu.DropDownItems.Add(openItem);
	fileMenu.DropDownItems.Add(exitItem);

	// Convert menu
	ToolStripMenuItem convertMenu = new ToolStripMenuItem("Convert");
	ms.Items.Add(convertMenu);

	goItem = new ToolStripMenuItem("&Go", null,
	    new EventHandler(Menu_Go));

	goItem.Enabled = false;

	convertMenu.DropDownItems.Add(goItem);

	// Add menu to form
	this.Controls.Add(ms);
    }

    private void setupStatusStrip()
    {
	statusStrip = new StatusStrip();

	ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
	statusLabel.Text = "Well?";

	ToolStripProgressBar progressBar = new ToolStripProgressBar();
	progressBar.Maximum = 100;
	progressBar.Value = 50;

	//statusStrip.Items.Add(statusLabel);
	statusStrip.Items.AddRange(new ToolStripStatusLabel[] { statusLabel });
	statusStrip.Items.AddRange(new ToolStripProgressBar[] { progressBar });

	statusStrip.Text = "Status!";

	this.Controls.Add(statusStrip);
    }

    private void OpenFile(String path)
    {
	string fileName = Path.GetFileName(path);
	string ext = Path.GetExtension(path);

	TreeNode node = new TreeNode(fileName);
	node.ToolTipText = path;

	if (ext.Equals(".css", StringComparison.OrdinalIgnoreCase))
	{
	    // Style sheet
	    tv.Nodes[1].Nodes.Add(node);
	    tv.Nodes[1].Expand();
	}
	else if (ext.Equals(".js", StringComparison.OrdinalIgnoreCase))
	{
	    // Script
	    tv.Nodes[2].Nodes.Add(node);
	    tv.Nodes[2].Expand();
	}
	else
	{
	    // Document
	    tv.Nodes[0].Nodes.Add(node);
	    tv.Nodes[0].Expand();

	    // at least one input document
	    goItem.Enabled = true;
	}
    }

    private void ExecProcess(String exePath, String args)
    {
	ProcessStartInfo startInfo =
	    new ProcessStartInfo(exePath, args);
	
	startInfo.CreateNoWindow = true;
	startInfo.UseShellExecute = false;
	startInfo.RedirectStandardInput = true;
	startInfo.RedirectStandardOutput = true;
	startInfo.RedirectStandardError = true;

	try
	{
	    Process proc = new Process();
	    proc.StartInfo = startInfo;

	    proc.Start();
	}
	catch (System.ComponentModel.Win32Exception ex)
	{
	    MessageBox.Show(ex.Message);
	}
    }

    private void RunPrince()
    {
	string exePath = Path.GetDirectoryName(Application.ExecutablePath);

	exePath += Path.DirectorySeparatorChar;
	exePath += "Engine";
	exePath += Path.DirectorySeparatorChar;
	exePath += "bin";
	exePath += Path.DirectorySeparatorChar;
	exePath += "prince.exe";

	ExecProcess(exePath, "");
    }

    private void Menu_Open(object sender, EventArgs e)
    {
	if (openDlg.ShowDialog() == DialogResult.OK)
	{
	    foreach (string FileName in openDlg.FileNames)
	    {
		OpenFile(FileName);
	    }
	}
    }
    
    private void Menu_Exit(object sender, EventArgs e)
    {
	Close();
    }

    private void Menu_Go(object sender, EventArgs e)
    {
	string path = tv.Nodes[0].Nodes[0].ToolTipText;

	path = Path.ChangeExtension(path, ".pdf");

	saveDlg.FileName = path;

	if (saveDlg.ShowDialog() == DialogResult.OK)
	{
	    MessageBox.Show(saveDlg.FileName);
	}
    }

    private void TreeView_KeyDown(object sender, KeyEventArgs e)
    {
	if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
	{
	    if (tv.SelectedNode != null && tv.SelectedNode.Parent != null)
	    {
		tv.SelectedNode.Remove();
	    }
	}
    }

    private void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
    {
	TreeNode node = (TreeNode) e.Item;

	if (node.Parent != null && e.Button == MouseButtons.Left)
	{
	    tv.SelectedNode = node;

	    DoDragDrop(e.Item, DragDropEffects.Move);
	}
    }
    
    private void TreeView_DragEnter(object sender, DragEventArgs e)
    {
	if (e.Data.GetDataPresent(DataFormats.FileDrop))
	{
	    e.Effect = DragDropEffects.Copy;
	}
	else
	{
	    e.Effect = e.AllowedEffect;
	}
    }

    private void TreeView_DragDrop(object sender, DragEventArgs e)
    {
	if (e.Data.GetDataPresent(DataFormats.FileDrop))
	{
	    string[] FileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, false);

	    if (FileNames != null)
	    {
		foreach (string FileName in FileNames)
		{
		    this.BeginInvoke(asyncOpenFile, new Object[] {FileName});
		}

		this.Activate();
	    }
	}
	else
	{
	    Point targetPoint = tv.PointToClient(new Point(e.X, e.Y));
	    TreeNode targetNode = tv.GetNodeAt(targetPoint);
	    TreeNode draggedNode = (TreeNode) e.Data.GetData(typeof(TreeNode));

	    if (targetNode == draggedNode)
	    {
		// nothing to do here
	    }
	    else if (targetNode.Parent == null)
	    {
		draggedNode.Remove();
		targetNode.Nodes.Insert(0, draggedNode);
		tv.SelectedNode = draggedNode;
	    }
	    else
	    {
		int offset = 0;

		if (targetNode.Parent == draggedNode.Parent)
		{
		    if (targetNode.Index > draggedNode.Index) offset = 1;
		}
		else
		{
		    if (targetNode.Parent.Index > draggedNode.Parent.Index) offset = 1;
		}

		draggedNode.Remove();
		targetNode.Parent.Nodes.Insert(targetNode.Index+offset, draggedNode);
		tv.SelectedNode = draggedNode;
	    }
	}
    }
    
    private void Form_DragEnter(object sender, DragEventArgs e)
    {
	if (e.Data.GetDataPresent(DataFormats.FileDrop))
	{
	    e.Effect = DragDropEffects.Copy;
	}
	else
	{
	    e.Effect = DragDropEffects.None;
	}
    }

    private void Form_DragDrop(object sender, DragEventArgs e)
    {
	string[] FileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, false);

	if (FileNames != null)
	{
	    foreach (string FileName in FileNames)
	    {
		this.BeginInvoke(asyncOpenFile, new Object[] {FileName});
	    }

	    this.Activate();
	}
    }
}

