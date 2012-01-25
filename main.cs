// Copyright (C) 2012 YesLogic Pty. Ltd.
// All rights reserved.

using System;
//using System.Collections;
//using System.Drawing;
using System.Windows.Forms;
 
public class GUI : Form
{
    private StatusStrip statusStrip;
    private delegate void AsyncOpenFile(String s);
    private AsyncOpenFile asyncOpenFile;
    private OpenFileDialog openDlg;
    private ListView lv1;

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
	    "Documents (*.html,*.htm,*.xml)|*.html;*.htm;*.xht;*.xhtml;*.xml|"+
	    "Style sheets (*.css)|*.css|"+
	    "Scripts (*.js)|*.js|"+
	    "All files (*.*)|*.*";

	// Listview for files
	lv1 = new ListView();
	lv1.View = View.List;
	lv1.Dock = DockStyle.Fill;
	this.Controls.Add(lv1);

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
	lv1.Items.Add(new ListViewItem(s));
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

