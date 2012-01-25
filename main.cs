// Copyright (C) 2012 YesLogic Pty. Ltd.
// All rights reserved.

using System;
using System.IO;
//using System.Collections;
//using System.Drawing;
using System.Windows.Forms;
 
public class GUI : Form
{
    private StatusStrip statusStrip;
    private delegate void AsyncOpenFile(String s);
    private AsyncOpenFile asyncOpenFile;
    private OpenFileDialog openDlg;
    private TreeView tv;

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
	
	// Setup open file dialog
	openDlg = new OpenFileDialog();
	openDlg.Multiselect = true;
	openDlg.Filter = 
	    "All web content|*.html;*.htm;*.svg;*.xht;*.xhtml;*.xml;*.css;*.js|"+
	    "Documents (HTML, XML, SVG)|*.html;*.htm;*.svg;*.xht;*.xhtml;*.xml|"+
	    "Style sheets (CSS)|*.css|"+
	    "Scripts (*.js)|*.js|"+
	    "All files (*.*)|*.*";

	// TreeView for files
	tv = new TreeView();
	tv.Dock = DockStyle.Fill;
	tv.Nodes.Add("Documents");
	tv.Nodes.Add("Style sheets");
	tv.Nodes.Add("Scripts");
	tv.ExpandAll();
	this.Controls.Add(tv);

	setupMenu();
	setupStatusStrip();
    }

    private void setupMenu()
    {
	MenuStrip ms = new MenuStrip();
	ms.Dock = DockStyle.Top;

	ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");

	ToolStripMenuItem openItem = new ToolStripMenuItem("&Open...", null,
	    new EventHandler(Menu_Open), Keys.Control | Keys.O);
	
	ToolStripMenuItem exitItem = new ToolStripMenuItem("E&xit", null,
	    new EventHandler(Menu_Exit));

	fileMenu.DropDownItems.Add(openItem);
	fileMenu.DropDownItems.Add(exitItem);

	ms.Items.Add(fileMenu);

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

    private void OpenFile(String s)
    {
	string ext = Path.GetExtension(s);

	if (ext.Equals(".css", StringComparison.OrdinalIgnoreCase))
	{
	    // Style sheet
	    tv.Nodes[1].Nodes.Add(s);
	}
	else if (ext.Equals(".js", StringComparison.OrdinalIgnoreCase))
	{
	    // Script
	    tv.Nodes[2].Nodes.Add(s);
	}
	else
	{
	    // Document
	    tv.Nodes[0].Nodes.Add(s);
	}
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

