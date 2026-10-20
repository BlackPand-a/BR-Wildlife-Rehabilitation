namespace BRWildlife;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dgvAnimals = new DataGridView();
        colID = new DataGridViewTextBoxColumn();
        colName = new DataGridViewTextBoxColumn();
        colSpecies = new DataGridViewTextBoxColumn();
        colAge = new DataGridViewTextBoxColumn();
        colScore = new DataGridViewTextBoxColumn();
        colStatus = new DataGridViewTextBoxColumn();
        colHousing = new DataGridViewTextBoxColumn();
        btndelete = new Button();
        btnSummary = new Button();
        txtSummary = new RichTextBox();
        ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
        SuspendLayout();
        // 
        // dgvAnimals
        // 
        dgvAnimals.AllowUserToAddRows = false;
        dgvAnimals.AllowUserToDeleteRows = false;
        dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAnimals.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colSpecies, colAge, colScore, colStatus, colHousing });
        dgvAnimals.Location = new Point(60, 11);
        dgvAnimals.Margin = new Padding(3, 2, 3, 2);
        dgvAnimals.MultiSelect = false;
        dgvAnimals.Name = "dgvAnimals";
        dgvAnimals.ReadOnly = true;
        dgvAnimals.RowHeadersWidth = 51;
        dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAnimals.Size = new Size(732, 329);
        dgvAnimals.TabIndex = 0;
        // 
        // colID
        // 
        colID.DataPropertyName = "ID";
        colID.HeaderText = "AnimalID";
        colID.MinimumWidth = 6;
        colID.Name = "colID";
        colID.ReadOnly = true;
        colID.Width = 125;
        // 
        // colName
        // 
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Name";
        colName.MinimumWidth = 6;
        colName.Name = "colName";
        colName.ReadOnly = true;
        colName.Width = 125;
        // 
        // colSpecies
        // 
        colSpecies.DataPropertyName = "Species";
        colSpecies.HeaderText = "Species";
        colSpecies.MinimumWidth = 6;
        colSpecies.Name = "colSpecies";
        colSpecies.ReadOnly = true;
        colSpecies.Width = 125;
        // 
        // colAge
        // 
        colAge.DataPropertyName = "Age";
        colAge.HeaderText = "Age";
        colAge.MinimumWidth = 6;
        colAge.Name = "colAge";
        colAge.ReadOnly = true;
        colAge.Width = 125;
        // 
        // colScore
        // 
        colScore.DataPropertyName = "Score";
        colScore.HeaderText = "Recovery Score";
        colScore.MinimumWidth = 6;
        colScore.Name = "colScore";
        colScore.ReadOnly = true;
        colScore.Width = 125;
        // 
        // colStatus
        // 
        colStatus.DataPropertyName = "Status";
        colStatus.HeaderText = "Status";
        colStatus.MinimumWidth = 6;
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        colStatus.Width = 125;
        // 
        // colHousing
        // 
        colHousing.DataPropertyName = "Housing Unit";
        colHousing.HeaderText = "Housing Unit";
        colHousing.MinimumWidth = 6;
        colHousing.Name = "colHousing";
        colHousing.ReadOnly = true;
        colHousing.Width = 125;
        // 
        // btndelete
        // 
        btndelete.Location = new Point(60, 345);
        btndelete.Name = "btndelete";
        btndelete.Size = new Size(129, 23);
        btndelete.TabIndex = 1;
        btndelete.Text = "Delete Animal";
        btndelete.UseVisualStyleBackColor = true;
        btndelete.Click += btndelete_Click;
        // 
        // btnSummary
        // 
        btnSummary.Location = new Point(428, 345);
        btnSummary.Name = "btnSummary";
        btnSummary.Size = new Size(124, 23);
        btnSummary.TabIndex = 2;
        btnSummary.Text = "Generate Summary";
        btnSummary.UseVisualStyleBackColor = true;
        btnSummary.Click += btnSummary_Click;
        // 
        // txtSummary
        // 
        txtSummary.Location = new Point(332, 391);
        txtSummary.Name = "txtSummary";
        txtSummary.ReadOnly = true;
        txtSummary.ScrollBars = RichTextBoxScrollBars.Vertical;
        txtSummary.Size = new Size(307, 128);
        txtSummary.TabIndex = 3;
        txtSummary.Text = "";
        txtSummary.WordWrap = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(851, 521);
        Controls.Add(txtSummary);
        Controls.Add(btnSummary);
        Controls.Add(btndelete);
        Controls.Add(dgvAnimals);
        Margin = new Padding(3, 2, 3, 2);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        Shown += Form1_Shown;
        ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvAnimals;
    private DataGridViewTextBoxColumn colID;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colSpecies;
    private DataGridViewTextBoxColumn colAge;
    private DataGridViewTextBoxColumn colScore;
    private DataGridViewTextBoxColumn colStatus;
    private DataGridViewTextBoxColumn colHousing;
    private Button btndelete;
    private Button btnSummary;
    private RichTextBox txtSummary;
}
