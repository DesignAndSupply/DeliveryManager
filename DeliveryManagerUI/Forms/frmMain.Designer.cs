namespace DeliveryManagerUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.txtPOID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGridView();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.cviewstoresstaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new DeliveryManagerUI.user_infoDataSet();
            this.cmbDelComp = new System.Windows.Forms.ComboBox();
            this.storesdeliverycompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_databaseDataSet = new DeliveryManagerUI.order_databaseDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c_view_stores_staffTableAdapter = new DeliveryManagerUI.user_infoDataSetTableAdapters.c_view_stores_staffTableAdapter();
            this.stores_delivery_companyTableAdapter = new DeliveryManagerUI.order_databaseDataSetTableAdapters.stores_delivery_companyTableAdapter();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.btnLogDel = new System.Windows.Forms.Button();
            this.btnPoUpdate = new System.Windows.Forms.Button();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewstoresstaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesdeliverycompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPOID
            // 
            this.txtPOID.Location = new System.Drawing.Point(83, 288);
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.Size = new System.Drawing.Size(70, 20);
            this.txtPOID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PO Number:";
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToResizeColumns = false;
            this.dg.AllowUserToResizeRows = false;
            this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(16, 369);
            this.dg.Name = "dg";
            this.dg.RowHeadersVisible = false;
            this.dg.Size = new System.Drawing.Size(801, 251);
            this.dg.TabIndex = 2;
            this.dg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick);
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            // 
            // cmbStaff
            // 
            this.cmbStaff.DataSource = this.cviewstoresstaffBindingSource;
            this.cmbStaff.DisplayMember = "fullname";
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(111, 31);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(170, 21);
            this.cmbStaff.TabIndex = 3;
            this.cmbStaff.ValueMember = "id";
            // 
            // cviewstoresstaffBindingSource
            // 
            this.cviewstoresstaffBindingSource.DataMember = "c_view_stores_staff";
            this.cviewstoresstaffBindingSource.DataSource = this.user_infoDataSet;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbDelComp
            // 
            this.cmbDelComp.DataSource = this.storesdeliverycompanyBindingSource;
            this.cmbDelComp.DisplayMember = "delivery_company_name";
            this.cmbDelComp.FormattingEnabled = true;
            this.cmbDelComp.Location = new System.Drawing.Point(111, 58);
            this.cmbDelComp.Name = "cmbDelComp";
            this.cmbDelComp.Size = new System.Drawing.Size(170, 21);
            this.cmbDelComp.TabIndex = 4;
            this.cmbDelComp.ValueMember = "id";
            // 
            // storesdeliverycompanyBindingSource
            // 
            this.storesdeliverycompanyBindingSource.DataMember = "stores_delivery_company";
            this.storesdeliverycompanyBindingSource.DataSource = this.order_databaseDataSet;
            // 
            // order_databaseDataSet
            // 
            this.order_databaseDataSet.DataSetName = "order_databaseDataSet";
            this.order_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recieved By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Delivery Company:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(17, 147);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(267, 88);
            this.txtDesc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description of packages";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.Location = new System.Drawing.Point(129, 92);
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(51, 20);
            this.txtBoxQty.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Amount of packages:";
            // 
            // c_view_stores_staffTableAdapter
            // 
            this.c_view_stores_staffTableAdapter.ClearBeforeFill = true;
            // 
            // stores_delivery_companyTableAdapter
            // 
            this.stores_delivery_companyTableAdapter.ClearBeforeFill = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(159, 287);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "View PO";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(680, 626);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(137, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit Del + PO Data";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIdentifier);
            this.groupBox1.Controls.Add(this.btnLogDel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 260);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Order/Del Note #:";
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Location = new System.Drawing.Point(99, 230);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(173, 20);
            this.txtIdentifier.TabIndex = 1;
            // 
            // btnLogDel
            // 
            this.btnLogDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogDel.Location = new System.Drawing.Point(682, 11);
            this.btnLogDel.Name = "btnLogDel";
            this.btnLogDel.Size = new System.Drawing.Size(116, 23);
            this.btnLogDel.TabIndex = 0;
            this.btnLogDel.Text = "Log Delivery Only";
            this.btnLogDel.UseVisualStyleBackColor = true;
            this.btnLogDel.Click += new System.EventHandler(this.btnLogDel_Click);
            // 
            // btnPoUpdate
            // 
            this.btnPoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoUpdate.Location = new System.Drawing.Point(703, 340);
            this.btnPoUpdate.Name = "btnPoUpdate";
            this.btnPoUpdate.Size = new System.Drawing.Size(114, 23);
            this.btnPoUpdate.TabIndex = 14;
            this.btnPoUpdate.Text = "Update PO Only";
            this.btnPoUpdate.UseVisualStyleBackColor = true;
            this.btnPoUpdate.Click += new System.EventHandler(this.btnPoUpdate_Click);
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.ForeColor = System.Drawing.Color.Red;
            this.lblOrderStatus.Location = new System.Drawing.Point(14, 346);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(25, 20);
            this.lblOrderStatus.TabIndex = 15;
            this.lblOrderStatus.Text = "....";
            this.lblOrderStatus.Click += new System.EventHandler(this.lblOrderStatus_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 656);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.btnPoUpdate);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDelComp);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPOID);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Delivery Manager:";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewstoresstaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesdeliverycompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPOID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.ComboBox cmbDelComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label5;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewstoresstaffBindingSource;
        private user_infoDataSetTableAdapters.c_view_stores_staffTableAdapter c_view_stores_staffTableAdapter;
        private order_databaseDataSet order_databaseDataSet;
        private System.Windows.Forms.BindingSource storesdeliverycompanyBindingSource;
        private order_databaseDataSetTableAdapters.stores_delivery_companyTableAdapter stores_delivery_companyTableAdapter;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogDel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.Button btnPoUpdate;
        private System.Windows.Forms.Label lblOrderStatus;
    }
}

