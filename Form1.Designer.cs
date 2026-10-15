namespace BRWildlife;

partial class Form1
{
    private System.Windows.Forms.Label lblAnimalID;
    private System.Windows.Forms.TextBox txtAnimalID;
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
        lblName = new Label();
        lblSpecies = new Label();
        lblRecoveryScore = new Label();
        lbllAge = new Label();
        txtRecoveryScore = new TextBox();
        txtAge = new TextBox();
        lblAnimalID = new Label();
        txtAnimalID = new TextBox();
        txtName = new TextBox();
        txtSpecies = new TextBox();
        btnAdd = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
        SuspendLayout();
        // 
        // dgvAnimals
        // 
        dgvAnimals.AllowUserToAddRows = false;
        dgvAnimals.AllowUserToDeleteRows = false;
        dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAnimals.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colSpecies, colAge, colScore, colStatus, colHousing });
        dgvAnimals.Location = new Point(85, 11);
        dgvAnimals.Margin = new Padding(3, 2, 3, 2);
        dgvAnimals.MultiSelect = false;
        dgvAnimals.Name = "dgvAnimals";
        dgvAnimals.ReadOnly = true;
        dgvAnimals.RowHeadersWidth = 51;
        dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAnimals.Size = new Size(913, 364);
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
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(85, 475);
        lblName.Name = "lblName";
        lblName.Size = new Size(39, 15);
        lblName.TabIndex = 2;
        lblName.Text = "Name";
        // 
        // lblSpecies
        // 
        lblSpecies.AutoSize = true;
        lblSpecies.Location = new Point(86, 530);
        lblSpecies.Name = "lblSpecies";
        lblSpecies.Size = new Size(46, 15);
        lblSpecies.TabIndex = 3;
        lblSpecies.Text = "Species";
        // 
        // lblRecoveryScore
        // 
        lblRecoveryScore.AutoSize = true;
        lblRecoveryScore.Location = new Point(401, 422);
        lblRecoveryScore.Name = "lblRecoveryScore";
        lblRecoveryScore.Size = new Size(87, 15);
        lblRecoveryScore.TabIndex = 4;
        lblRecoveryScore.Text = "Recovery Score";
        // 
        // lbllAge
        // 
        lbllAge.AutoSize = true;
        lbllAge.Location = new Point(401, 478);
        lbllAge.Name = "lbllAge";
        lbllAge.Size = new Size(28, 15);
        lbllAge.TabIndex = 5;
        lbllAge.Text = "Age";
        // 
        // txtRecoveryScore
        // 
        txtRecoveryScore.Location = new Point(532, 419);
        txtRecoveryScore.Name = "txtRecoveryScore";
        txtRecoveryScore.Size = new Size(100, 23);
        txtRecoveryScore.TabIndex = 9;
        // 
        // txtAge
        // 
        txtAge.Location = new Point(532, 475);
        txtAge.Name = "txtAge";
        txtAge.Size = new Size(100, 23);
        txtAge.TabIndex = 10;
        // 
        // lblAnimalID
        // 
        lblAnimalID.AutoSize = true;
        lblAnimalID.Location = new Point(86, 419);
        lblAnimalID.Name = "lblAnimalID";
        lblAnimalID.Size = new Size(56, 15);
        lblAnimalID.TabIndex = 11;
        lblAnimalID.Text = "AnimalID";
        // 
        // txtAnimalID
        // 
        txtAnimalID.Location = new Point(168, 416);
        txtAnimalID.Name = "txtAnimalID";
        txtAnimalID.Size = new Size(100, 23);
        txtAnimalID.TabIndex = 12;
        // 
        // txtName
        // 
        txtName.Location = new Point(168, 467);
        txtName.Name = "txtName";
        txtName.Size = new Size(100, 23);
        txtName.TabIndex = 13;
        // 
        // txtSpecies
        // 
        txtSpecies.Location = new Point(168, 522);
        txtSpecies.Name = "txtSpecies";
        txtSpecies.Size = new Size(100, 23);
        txtSpecies.TabIndex = 14;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(85, 610);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 15;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1113, 757);
        Controls.Add(btnAdd);
        Controls.Add(txtSpecies);
        Controls.Add(txtName);
        Controls.Add(txtAnimalID);
        Controls.Add(lblAnimalID);
        Controls.Add(txtAge);
        Controls.Add(txtRecoveryScore);
        Controls.Add(lbllAge);
        Controls.Add(lblRecoveryScore);
        Controls.Add(lblSpecies);
        Controls.Add(lblName);
        Controls.Add(dgvAnimals);
        Margin = new Padding(3, 2, 3, 2);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
        ResumeLayout(false);
        PerformLayout();
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
    private Label label1;
    private Label lblName;
    private Label lblSpecies;
    private Label lblRecoveryScore;
    private Label lbllAge;
    private TextBox textBox1;
    private TextBox txtName;
    private TextBox txtSpecies;
    private TextBox txtRecoveryScore;
    private TextBox txtAge;
    private Button btnAdd;
}
