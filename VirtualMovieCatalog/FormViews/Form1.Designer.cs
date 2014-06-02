namespace VirtualMovieCatalog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.moviesListView = new System.Windows.Forms.ListView();
            this.movieNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchCriteriaComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.movieDurationTextBox = new System.Windows.Forms.TextBox();
            this.durataFilmLabel = new System.Windows.Forms.Label();
            this.movieCdDvdTextBox = new System.Windows.Forms.TextBox();
            this.CDDVDLabel = new System.Windows.Forms.Label();
            this.movieTrailerUrlTextBox = new System.Windows.Forms.TextBox();
            this.videoLinkLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.movieRatingTextBox = new System.Windows.Forms.TextBox();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.movieReleaseYearTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.movieDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.movieActorsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.movieRegizorTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.movieGenreTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.movieNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addMovieButton = new System.Windows.Forms.Button();
            this.deleteMovieButton = new System.Windows.Forms.Button();
            this.editMovieButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.movieSubtitleTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // moviesListView
            // 
            this.moviesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.moviesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.movieNumber,
            this.nameColumn});
            this.moviesListView.FullRowSelect = true;
            this.moviesListView.GridLines = true;
            this.moviesListView.Location = new System.Drawing.Point(12, 91);
            this.moviesListView.MultiSelect = false;
            this.moviesListView.Name = "moviesListView";
            this.moviesListView.Size = new System.Drawing.Size(158, 558);
            this.moviesListView.TabIndex = 0;
            this.moviesListView.UseCompatibleStateImageBehavior = false;
            this.moviesListView.View = System.Windows.Forms.View.Details;
            this.moviesListView.Click += new System.EventHandler(this.moviesListView_Click);
            // 
            // movieNumber
            // 
            this.movieNumber.Text = "Nr";
            this.movieNumber.Width = 32;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Nume";
            this.nameColumn.Width = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista filme";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(271, 40);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Cauta";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchCriteriaComboBox
            // 
            this.searchCriteriaComboBox.FormattingEnabled = true;
            this.searchCriteriaComboBox.Location = new System.Drawing.Point(176, 41);
            this.searchCriteriaComboBox.Name = "searchCriteriaComboBox";
            this.searchCriteriaComboBox.Size = new System.Drawing.Size(89, 21);
            this.searchCriteriaComboBox.TabIndex = 3;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(10, 40);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(158, 20);
            this.searchTextBox.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToPDFToolStripMenuItem,
            this.exportToXMLToolStripMenuItem,
            this.exportToCSVToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            this.exportToPDFToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportToPDFToolStripMenuItem.Text = "Export to PDF";
            // 
            // exportToXMLToolStripMenuItem
            // 
            this.exportToXMLToolStripMenuItem.Name = "exportToXMLToolStripMenuItem";
            this.exportToXMLToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportToXMLToolStripMenuItem.Text = "Export to XML";
            // 
            // exportToCSVToolStripMenuItem
            // 
            this.exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            this.exportToCSVToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportToCSVToolStripMenuItem.Text = "Export to CSV";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(176, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 558);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informatii film";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.movieSubtitleTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.movieDurationTextBox);
            this.panel1.Controls.Add(this.durataFilmLabel);
            this.panel1.Controls.Add(this.movieCdDvdTextBox);
            this.panel1.Controls.Add(this.CDDVDLabel);
            this.panel1.Controls.Add(this.movieTrailerUrlTextBox);
            this.panel1.Controls.Add(this.videoLinkLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.movieRatingTextBox);
            this.panel1.Controls.Add(this.ratingLabel);
            this.panel1.Controls.Add(this.movieReleaseYearTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.movieDescriptionTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.movieActorsTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.movieRegizorTextbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.movieGenreTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.movieNameTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 539);
            this.panel1.TabIndex = 0;
            // 
            // movieDurationTextBox
            // 
            this.movieDurationTextBox.Location = new System.Drawing.Point(113, 223);
            this.movieDurationTextBox.Name = "movieDurationTextBox";
            this.movieDurationTextBox.Size = new System.Drawing.Size(54, 20);
            this.movieDurationTextBox.TabIndex = 20;
            // 
            // durataFilmLabel
            // 
            this.durataFilmLabel.AutoSize = true;
            this.durataFilmLabel.Location = new System.Drawing.Point(110, 207);
            this.durataFilmLabel.Name = "durataFilmLabel";
            this.durataFilmLabel.Size = new System.Drawing.Size(39, 13);
            this.durataFilmLabel.TabIndex = 19;
            this.durataFilmLabel.Text = "Durata";
            // 
            // movieCdDvdTextBox
            // 
            this.movieCdDvdTextBox.Location = new System.Drawing.Point(6, 175);
            this.movieCdDvdTextBox.Name = "movieCdDvdTextBox";
            this.movieCdDvdTextBox.Size = new System.Drawing.Size(161, 20);
            this.movieCdDvdTextBox.TabIndex = 18;
            // 
            // CDDVDLabel
            // 
            this.CDDVDLabel.AutoSize = true;
            this.CDDVDLabel.Location = new System.Drawing.Point(3, 159);
            this.CDDVDLabel.Name = "CDDVDLabel";
            this.CDDVDLabel.Size = new System.Drawing.Size(50, 13);
            this.CDDVDLabel.TabIndex = 17;
            this.CDDVDLabel.Text = "CD/DVD";
            // 
            // movieTrailerUrlTextBox
            // 
            this.movieTrailerUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.movieTrailerUrlTextBox.Location = new System.Drawing.Point(184, 416);
            this.movieTrailerUrlTextBox.Name = "movieTrailerUrlTextBox";
            this.movieTrailerUrlTextBox.Size = new System.Drawing.Size(584, 20);
            this.movieTrailerUrlTextBox.TabIndex = 16;
            // 
            // videoLinkLabel
            // 
            this.videoLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.videoLinkLabel.AutoSize = true;
            this.videoLinkLabel.Location = new System.Drawing.Point(181, 400);
            this.videoLinkLabel.Name = "videoLinkLabel";
            this.videoLinkLabel.Size = new System.Drawing.Size(61, 13);
            this.videoLinkLabel.TabIndex = 15;
            this.videoLinkLabel.Text = "Trailer URL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(184, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(574, 385);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // movieRatingTextBox
            // 
            this.movieRatingTextBox.Location = new System.Drawing.Point(69, 223);
            this.movieRatingTextBox.Name = "movieRatingTextBox";
            this.movieRatingTextBox.Size = new System.Drawing.Size(35, 20);
            this.movieRatingTextBox.TabIndex = 13;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(66, 207);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(38, 13);
            this.ratingLabel.TabIndex = 12;
            this.ratingLabel.Text = "Rating";
            // 
            // movieReleaseYearTextBox
            // 
            this.movieReleaseYearTextBox.Location = new System.Drawing.Point(6, 223);
            this.movieReleaseYearTextBox.Name = "movieReleaseYearTextBox";
            this.movieReleaseYearTextBox.Size = new System.Drawing.Size(54, 20);
            this.movieReleaseYearTextBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "An aparitie";
            // 
            // movieDescriptionTextBox
            // 
            this.movieDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.movieDescriptionTextBox.Location = new System.Drawing.Point(184, 464);
            this.movieDescriptionTextBox.Multiline = true;
            this.movieDescriptionTextBox.Name = "movieDescriptionTextBox";
            this.movieDescriptionTextBox.Size = new System.Drawing.Size(584, 61);
            this.movieDescriptionTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Descriere";
            // 
            // movieActorsTextBox
            // 
            this.movieActorsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.movieActorsTextBox.Location = new System.Drawing.Point(6, 319);
            this.movieActorsTextBox.Multiline = true;
            this.movieActorsTextBox.Name = "movieActorsTextBox";
            this.movieActorsTextBox.Size = new System.Drawing.Size(161, 206);
            this.movieActorsTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Actori";
            // 
            // movieRegizorTextbox
            // 
            this.movieRegizorTextbox.Location = new System.Drawing.Point(6, 127);
            this.movieRegizorTextbox.Name = "movieRegizorTextbox";
            this.movieRegizorTextbox.Size = new System.Drawing.Size(161, 20);
            this.movieRegizorTextbox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Regizor";
            // 
            // movieGenreTextBox
            // 
            this.movieGenreTextBox.Location = new System.Drawing.Point(6, 79);
            this.movieGenreTextBox.Name = "movieGenreTextBox";
            this.movieGenreTextBox.Size = new System.Drawing.Size(161, 20);
            this.movieGenreTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gen";
            // 
            // movieNameTextBox
            // 
            this.movieNameTextBox.Location = new System.Drawing.Point(6, 30);
            this.movieNameTextBox.Name = "movieNameTextBox";
            this.movieNameTextBox.Size = new System.Drawing.Size(161, 20);
            this.movieNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nume";
            // 
            // addMovieButton
            // 
            this.addMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addMovieButton.Location = new System.Drawing.Point(12, 655);
            this.addMovieButton.Name = "addMovieButton";
            this.addMovieButton.Size = new System.Drawing.Size(75, 23);
            this.addMovieButton.TabIndex = 7;
            this.addMovieButton.Text = "Adauga film";
            this.addMovieButton.UseVisualStyleBackColor = true;
            // 
            // deleteMovieButton
            // 
            this.deleteMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteMovieButton.Location = new System.Drawing.Point(93, 655);
            this.deleteMovieButton.Name = "deleteMovieButton";
            this.deleteMovieButton.Size = new System.Drawing.Size(75, 23);
            this.deleteMovieButton.TabIndex = 8;
            this.deleteMovieButton.Text = "Sterge film";
            this.deleteMovieButton.UseVisualStyleBackColor = true;
            // 
            // editMovieButton
            // 
            this.editMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMovieButton.Location = new System.Drawing.Point(179, 655);
            this.editMovieButton.Name = "editMovieButton";
            this.editMovieButton.Size = new System.Drawing.Size(99, 23);
            this.editMovieButton.TabIndex = 9;
            this.editMovieButton.Text = "Editeaza film";
            this.editMovieButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Subtitrari";
            // 
            // movieSubtitleTextBox
            // 
            this.movieSubtitleTextBox.Location = new System.Drawing.Point(6, 271);
            this.movieSubtitleTextBox.Name = "movieSubtitleTextBox";
            this.movieSubtitleTextBox.Size = new System.Drawing.Size(161, 20);
            this.movieSubtitleTextBox.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 709);
            this.Controls.Add(this.editMovieButton);
            this.Controls.Add(this.deleteMovieButton);
            this.Controls.Add(this.addMovieButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchCriteriaComboBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moviesListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(585, 465);
            this.Name = "Form1";
            this.Text = "VortualMovieCatalog";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView moviesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox searchCriteriaComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox movieNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox movieGenreTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader movieNumber;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.TextBox movieActorsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox movieRegizorTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addMovieButton;
        private System.Windows.Forms.Button deleteMovieButton;
        private System.Windows.Forms.Button editMovieButton;
        private System.Windows.Forms.TextBox movieDescriptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox movieReleaseYearTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox movieRatingTextBox;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.TextBox movieTrailerUrlTextBox;
        private System.Windows.Forms.Label videoLinkLabel;
        private System.Windows.Forms.TextBox movieDurationTextBox;
        private System.Windows.Forms.Label durataFilmLabel;
        private System.Windows.Forms.TextBox movieCdDvdTextBox;
        private System.Windows.Forms.Label CDDVDLabel;
        private System.Windows.Forms.TextBox movieSubtitleTextBox;
        private System.Windows.Forms.Label label8;


    }
}

