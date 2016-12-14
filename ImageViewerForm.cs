using System;
using System.Windows.Forms;
using System.Drawing;

public class ImageViewerForm : Form
{
	Panel panel;
	PictureBox pictureBox;
	Button btnRotate;

	public ImageViewerForm()
	{

		panel = new Panel();
		panel.BackColor = Color.LightGray;
		panel.Size = new Size(this.ClientRectangle.Width,50);
		panel.Location = new Point(0,this.ClientRectangle.Height - panel.Height);
		panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

		pictureBox = new PictureBox();
		pictureBox.BackColor = Color.Gray;
		pictureBox.Image = Image.FromFile("laptop.jpg");
		pictureBox.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - this.panel.Height);
		//pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top |  AnchorStyles.Bottom;		
		pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
		
		btnRotate = new Button();
		btnRotate.Text = "Rotate";
		btnRotate.Height = panel.Height;
		btnRotate.Click += new EventHandler(btnRotate_Click);

		panel.Controls.Add(btnRotate);
		this.Controls.Add(panel);
		this.Controls.Add(pictureBox);
		this.Resize += new EventHandler(imageViewerForm_resize);

		Center();

	}




	public void btnRotate_Click(Object sender, EventArgs e)
	{
		pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
		pictureBox.Refresh();
	}


	public void Center()
	{
		//center
		Point p = new Point(0,0);
		p.X = (int) this.ClientRectangle.Width / 2;
		p.Y = (int) (this.ClientRectangle.Height - 50) / 2;
		
		//offset
		p.X = p.X - pictureBox.Width / 2;
		p.Y = p.Y - pictureBox.Height /2 ;

		pictureBox.Top = p.Y;
		pictureBox.Left = p.X;

		pictureBox.Refresh();
	}

	public void imageViewerForm_resize(Object sender, EventArgs e)
	{
		Center();
	}
}



