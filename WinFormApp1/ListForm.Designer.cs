
namespace WinFormApp1
{
    partial class ListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.listadotxt = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolDetalle = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pbArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado.Location = new System.Drawing.Point(18, 149);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.RowHeadersWidth = 62;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(968, 445);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.SelectionChanged += new System.EventHandler(this.dgvListado_SelectionChanged);
            // 
            // listadotxt
            // 
            this.listadotxt.AutoSize = true;
            this.listadotxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadotxt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listadotxt.Location = new System.Drawing.Point(18, 77);
            this.listadotxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listadotxt.Name = "listadotxt";
            this.listadotxt.Size = new System.Drawing.Size(331, 40);
            this.listadotxt.TabIndex = 2;
            this.listadotxt.Text = "Listado de Articulos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAgregar,
            this.toolStripButton2,
            this.toolEliminar,
            this.toolDetalle,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1540, 40);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAgregar
            // 
            this.toolAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolAgregar.Image = global::WinFormApp1.Properties.Resources.agregar;
            this.toolAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAgregar.Name = "toolAgregar";
            this.toolAgregar.Size = new System.Drawing.Size(125, 35);
            this.toolAgregar.Text = "Agregar";
            this.toolAgregar.Click += new System.EventHandler(this.toolAgregar_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripButton2.Image = global::WinFormApp1.Properties.Resources.modificar;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(140, 35);
            this.toolStripButton2.Text = "Modificar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolEliminar
            // 
            this.toolEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolEliminar.Image = global::WinFormApp1.Properties.Resources.eliminar;
            this.toolEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEliminar.Name = "toolEliminar";
            this.toolEliminar.Size = new System.Drawing.Size(125, 35);
            this.toolEliminar.Text = "Eliminar";
            this.toolEliminar.Click += new System.EventHandler(this.toolEliminar_Click);
            // 
            // toolDetalle
            // 
            this.toolDetalle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolDetalle.Image = global::WinFormApp1.Properties.Resources.detalle;
            this.toolDetalle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDetalle.Name = "toolDetalle";
            this.toolDetalle.Size = new System.Drawing.Size(114, 35);
            this.toolDetalle.Text = "Detalle";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.Image = global::WinFormApp1.Properties.Resources.busqueda;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(157, 35);
            this.toolStripDropDownButton1.Text = "Busqueda";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // pbArticulo
            // 
            this.pbArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbArticulo.Location = new System.Drawing.Point(1035, 149);
            this.pbArticulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbArticulo.Name = "pbArticulo";
            this.pbArticulo.Size = new System.Drawing.Size(488, 445);
            this.pbArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArticulo.TabIndex = 1;
            this.pbArticulo.TabStop = false;
            // 
            // frmListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(1540, 626);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listadotxt);
            this.Controls.Add(this.pbArticulo);
            this.Controls.Add(this.dgvListado);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Articulos";
            this.Load += new System.EventHandler(this.frmListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.PictureBox pbArticulo;
        private System.Windows.Forms.Label listadotxt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolEliminar;
        private System.Windows.Forms.ToolStripButton toolDetalle;
        private System.Windows.Forms.ToolStripButton toolAgregar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    }
}