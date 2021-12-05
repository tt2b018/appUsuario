
namespace AppUsuario
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rutaImagen = new System.Windows.Forms.Label();
            this.btnSelectImg = new System.Windows.Forms.Button();
            this.btnSelectAutorKey = new System.Windows.Forms.Button();
            this.btnSelectReceptorKey = new System.Windows.Forms.Button();
            this.btnExtrInfo = new System.Windows.Forms.Button();
            this.labelInfoAutor = new System.Windows.Forms.Label();
            this.infoAutor = new System.Windows.Forms.Label();
            this.infoReceptor = new System.Windows.Forms.Label();
            this.labelInfoReceptor = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.rutaLlaveReceptor = new System.Windows.Forms.Label();
            this.rutaLlaveAutor = new System.Windows.Forms.Label();
            this.estadoA = new System.Windows.Forms.Label();
            this.estadoB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rutaImagen
            // 
            this.rutaImagen.BackColor = System.Drawing.Color.Azure;
            this.rutaImagen.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rutaImagen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rutaImagen.Location = new System.Drawing.Point(28, 96);
            this.rutaImagen.Name = "rutaImagen";
            this.rutaImagen.Size = new System.Drawing.Size(483, 32);
            this.rutaImagen.TabIndex = 0;
            this.rutaImagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rutaImagen.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSelectImg
            // 
            this.btnSelectImg.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSelectImg.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSelectImg.Location = new System.Drawing.Point(517, 96);
            this.btnSelectImg.Name = "btnSelectImg";
            this.btnSelectImg.Size = new System.Drawing.Size(106, 32);
            this.btnSelectImg.TabIndex = 1;
            this.btnSelectImg.Text = "IMAGEN";
            this.btnSelectImg.UseVisualStyleBackColor = false;
            this.btnSelectImg.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectAutorKey
            // 
            this.btnSelectAutorKey.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSelectAutorKey.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectAutorKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSelectAutorKey.Location = new System.Drawing.Point(517, 147);
            this.btnSelectAutorKey.Name = "btnSelectAutorKey";
            this.btnSelectAutorKey.Size = new System.Drawing.Size(106, 35);
            this.btnSelectAutorKey.TabIndex = 2;
            this.btnSelectAutorKey.Text = "LLAVE AUTOR";
            this.btnSelectAutorKey.UseVisualStyleBackColor = false;
            this.btnSelectAutorKey.Click += new System.EventHandler(this.btnSelectAutorKey_Click);
            // 
            // btnSelectReceptorKey
            // 
            this.btnSelectReceptorKey.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSelectReceptorKey.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectReceptorKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSelectReceptorKey.Location = new System.Drawing.Point(517, 200);
            this.btnSelectReceptorKey.Name = "btnSelectReceptorKey";
            this.btnSelectReceptorKey.Size = new System.Drawing.Size(106, 35);
            this.btnSelectReceptorKey.TabIndex = 3;
            this.btnSelectReceptorKey.Text = "LLAVE RECEPTOR";
            this.btnSelectReceptorKey.UseVisualStyleBackColor = false;
            this.btnSelectReceptorKey.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExtrInfo
            // 
            this.btnExtrInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExtrInfo.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExtrInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExtrInfo.Location = new System.Drawing.Point(258, 247);
            this.btnExtrInfo.Name = "btnExtrInfo";
            this.btnExtrInfo.Size = new System.Drawing.Size(137, 35);
            this.btnExtrInfo.TabIndex = 5;
            this.btnExtrInfo.Text = "EXTRAER INFORMACIÓN";
            this.btnExtrInfo.UseVisualStyleBackColor = false;
            this.btnExtrInfo.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelInfoAutor
            // 
            this.labelInfoAutor.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfoAutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelInfoAutor.Location = new System.Drawing.Point(28, 290);
            this.labelInfoAutor.Name = "labelInfoAutor";
            this.labelInfoAutor.Size = new System.Drawing.Size(210, 23);
            this.labelInfoAutor.TabIndex = 6;
            this.labelInfoAutor.Text = "Información del autor";
            this.labelInfoAutor.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // infoAutor
            // 
            this.infoAutor.BackColor = System.Drawing.Color.Azure;
            this.infoAutor.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoAutor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.infoAutor.Location = new System.Drawing.Point(28, 313);
            this.infoAutor.Name = "infoAutor";
            this.infoAutor.Size = new System.Drawing.Size(595, 79);
            this.infoAutor.TabIndex = 7;
            // 
            // infoReceptor
            // 
            this.infoReceptor.BackColor = System.Drawing.Color.Azure;
            this.infoReceptor.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoReceptor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.infoReceptor.Location = new System.Drawing.Point(28, 431);
            this.infoReceptor.Name = "infoReceptor";
            this.infoReceptor.Size = new System.Drawing.Size(595, 79);
            this.infoReceptor.TabIndex = 9;
            this.infoReceptor.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelInfoReceptor
            // 
            this.labelInfoReceptor.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfoReceptor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelInfoReceptor.Location = new System.Drawing.Point(28, 408);
            this.labelInfoReceptor.Name = "labelInfoReceptor";
            this.labelInfoReceptor.Size = new System.Drawing.Size(239, 23);
            this.labelInfoReceptor.TabIndex = 8;
            this.labelInfoReceptor.Text = "Información del receptor";
            this.labelInfoReceptor.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.AliceBlue;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerarReporte.Location = new System.Drawing.Point(287, 536);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(77, 35);
            this.btnGenerarReporte.TabIndex = 10;
            this.btnGenerarReporte.Text = "REPORTE";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimpiar.CausesValidation = false;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(547, 23);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(46, 43);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // rutaLlaveReceptor
            // 
            this.rutaLlaveReceptor.BackColor = System.Drawing.Color.Azure;
            this.rutaLlaveReceptor.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rutaLlaveReceptor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rutaLlaveReceptor.Location = new System.Drawing.Point(28, 200);
            this.rutaLlaveReceptor.Name = "rutaLlaveReceptor";
            this.rutaLlaveReceptor.Size = new System.Drawing.Size(483, 32);
            this.rutaLlaveReceptor.TabIndex = 14;
            this.rutaLlaveReceptor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rutaLlaveAutor
            // 
            this.rutaLlaveAutor.BackColor = System.Drawing.Color.Azure;
            this.rutaLlaveAutor.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rutaLlaveAutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rutaLlaveAutor.Location = new System.Drawing.Point(28, 150);
            this.rutaLlaveAutor.Name = "rutaLlaveAutor";
            this.rutaLlaveAutor.Size = new System.Drawing.Size(483, 32);
            this.rutaLlaveAutor.TabIndex = 15;
            this.rutaLlaveAutor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // estadoA
            // 
            this.estadoA.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.estadoA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.estadoA.Location = new System.Drawing.Point(413, 290);
            this.estadoA.Name = "estadoA";
            this.estadoA.Size = new System.Drawing.Size(210, 23);
            this.estadoA.TabIndex = 16;
            this.estadoA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // estadoB
            // 
            this.estadoB.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.estadoB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.estadoB.Location = new System.Drawing.Point(413, 408);
            this.estadoB.Name = "estadoB";
            this.estadoB.Size = new System.Drawing.Size(210, 23);
            this.estadoB.TabIndex = 17;
            this.estadoB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(650, 583);
            this.Controls.Add(this.estadoB);
            this.Controls.Add(this.estadoA);
            this.Controls.Add(this.rutaLlaveAutor);
            this.Controls.Add(this.rutaLlaveReceptor);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.infoReceptor);
            this.Controls.Add(this.labelInfoReceptor);
            this.Controls.Add(this.infoAutor);
            this.Controls.Add(this.labelInfoAutor);
            this.Controls.Add(this.btnExtrInfo);
            this.Controls.Add(this.btnSelectReceptorKey);
            this.Controls.Add(this.btnSelectAutorKey);
            this.Controls.Add(this.btnSelectImg);
            this.Controls.Add(this.rutaImagen);
            this.Name = "Form1";
            this.Text = "Extractor de información";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label rutaImagen;
        private System.Windows.Forms.Button btnSelectImg;
        private System.Windows.Forms.Button btnSelectAutorKey;
        private System.Windows.Forms.Button btnSelectReceptorKey;
        private System.Windows.Forms.Button btnExtrInfo;
        private System.Windows.Forms.Label labelInfoAutor;
        private System.Windows.Forms.Label infoAutor;
        private System.Windows.Forms.Label infoReceptor;
        private System.Windows.Forms.Label labelInfoReceptor;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label rutaLlaveReceptor;
        private System.Windows.Forms.Label rutaLlaveAutor;
        private System.Windows.Forms.Label estadoA;
        private System.Windows.Forms.Label estadoB;
    }
}

