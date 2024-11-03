
using System;

namespace Capa_Vista_AmmyCatun
{
    partial class Transporte_Vehiculos
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Txt_ID_2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Txt_Destino = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Cmb_Forma = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Guia = new System.Windows.Forms.TextBox();
            this.Txt_id_Vehiculo = new System.Windows.Forms.TextBox();
            this.lbl_Id_Vehiculo = new System.Windows.Forms.Label();
            this.dtp_Fecha_Traslado = new System.Windows.Forms.DateTimePicker();
            this.dtp_Fecha_Emision = new System.Windows.Forms.DateTimePicker();
            this.Txt_LLegada = new System.Windows.Forms.TextBox();
            this.Txt_Recojo = new System.Windows.Forms.TextBox();
            this.Txt_Partida = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_ID_1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Lbl_DATOS = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Dgv_Cliente = new System.Windows.Forms.DataGridView();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cliente)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Ayuda);
            this.groupBox2.Controls.Add(this.Btn_Reporte);
            this.groupBox2.Controls.Add(this.Btn_Modificar);
            this.groupBox2.Controls.Add(this.Btn_Eliminar);
            this.groupBox2.Controls.Add(this.Btn_Ingresar);
            this.groupBox2.Location = new System.Drawing.Point(1204, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 259);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MANTENIMIENTO";
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Reporte.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.reporte;
            this.Btn_Reporte.Location = new System.Drawing.Point(192, 151);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(127, 78);
            this.Btn_Reporte.TabIndex = 4;
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Modificar.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.EDITAR_V4;
            this.Btn_Modificar.Location = new System.Drawing.Point(46, 151);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(126, 84);
            this.Btn_Modificar.TabIndex = 2;
            this.Btn_Modificar.UseVisualStyleBackColor = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Eliminar.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.BORRAR_V4;
            this.Btn_Eliminar.Location = new System.Drawing.Point(198, 34);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(121, 92);
            this.Btn_Eliminar.TabIndex = 1;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Ingresar.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.guardar;
            this.Btn_Ingresar.Location = new System.Drawing.Point(46, 34);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(126, 88);
            this.Btn_Ingresar.TabIndex = 0;
            this.Btn_Ingresar.UseVisualStyleBackColor = false;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.Txt_ID_2);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(481, 360);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 179);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DESTINATARIO";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.button2.Location = new System.Drawing.Point(51, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 40);
            this.button2.TabIndex = 29;
            this.button2.Text = "Formulario Destinatario";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txt_ID_2
            // 
            this.Txt_ID_2.Location = new System.Drawing.Point(210, 46);
            this.Txt_ID_2.Name = "Txt_ID_2";
            this.Txt_ID_2.Size = new System.Drawing.Size(85, 26);
            this.Txt_ID_2.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(156, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "ID:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Txt_Destino);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.Cmb_Forma);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(30, 577);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1114, 78);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            // 
            // Txt_Destino
            // 
            this.Txt_Destino.Location = new System.Drawing.Point(132, 32);
            this.Txt_Destino.Name = "Txt_Destino";
            this.Txt_Destino.Size = new System.Drawing.Size(277, 26);
            this.Txt_Destino.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(536, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 20);
            this.label18.TabIndex = 16;
            this.label18.Text = "FORMA DE PAGO:";
            // 
            // Cmb_Forma
            // 
            this.Cmb_Forma.FormattingEnabled = true;
            this.Cmb_Forma.Location = new System.Drawing.Point(722, 26);
            this.Cmb_Forma.Name = "Cmb_Forma";
            this.Cmb_Forma.Size = new System.Drawing.Size(342, 28);
            this.Cmb_Forma.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "DESTINO: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Txt_Guia);
            this.groupBox3.Controls.Add(this.Txt_id_Vehiculo);
            this.groupBox3.Controls.Add(this.lbl_Id_Vehiculo);
            this.groupBox3.Controls.Add(this.dtp_Fecha_Traslado);
            this.groupBox3.Controls.Add(this.dtp_Fecha_Emision);
            this.groupBox3.Controls.Add(this.Txt_LLegada);
            this.groupBox3.Controls.Add(this.Txt_Recojo);
            this.groupBox3.Controls.Add(this.Txt_Partida);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(50, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1526, 237);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATOS PEDIDO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1081, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Id Guia";
            // 
            // Txt_Guia
            // 
            this.Txt_Guia.Location = new System.Drawing.Point(1180, 108);
            this.Txt_Guia.Name = "Txt_Guia";
            this.Txt_Guia.Size = new System.Drawing.Size(277, 26);
            this.Txt_Guia.TabIndex = 29;
            // 
            // Txt_id_Vehiculo
            // 
            this.Txt_id_Vehiculo.Location = new System.Drawing.Point(1190, 45);
            this.Txt_id_Vehiculo.Name = "Txt_id_Vehiculo";
            this.Txt_id_Vehiculo.Size = new System.Drawing.Size(277, 26);
            this.Txt_id_Vehiculo.TabIndex = 28;
            // 
            // lbl_Id_Vehiculo
            // 
            this.lbl_Id_Vehiculo.AutoSize = true;
            this.lbl_Id_Vehiculo.Location = new System.Drawing.Point(1081, 48);
            this.lbl_Id_Vehiculo.Name = "lbl_Id_Vehiculo";
            this.lbl_Id_Vehiculo.Size = new System.Drawing.Size(84, 20);
            this.lbl_Id_Vehiculo.TabIndex = 27;
            this.lbl_Id_Vehiculo.Text = "Id vehiculo";
            // 
            // dtp_Fecha_Traslado
            // 
            this.dtp_Fecha_Traslado.Location = new System.Drawing.Point(780, 43);
            this.dtp_Fecha_Traslado.Name = "dtp_Fecha_Traslado";
            this.dtp_Fecha_Traslado.Size = new System.Drawing.Size(277, 26);
            this.dtp_Fecha_Traslado.TabIndex = 26;
            // 
            // dtp_Fecha_Emision
            // 
            this.dtp_Fecha_Emision.Location = new System.Drawing.Point(226, 49);
            this.dtp_Fecha_Emision.Name = "dtp_Fecha_Emision";
            this.dtp_Fecha_Emision.Size = new System.Drawing.Size(277, 26);
            this.dtp_Fecha_Emision.TabIndex = 25;
            // 
            // Txt_LLegada
            // 
            this.Txt_LLegada.Location = new System.Drawing.Point(780, 108);
            this.Txt_LLegada.Name = "Txt_LLegada";
            this.Txt_LLegada.Size = new System.Drawing.Size(277, 26);
            this.Txt_LLegada.TabIndex = 23;
            // 
            // Txt_Recojo
            // 
            this.Txt_Recojo.Location = new System.Drawing.Point(226, 166);
            this.Txt_Recojo.Name = "Txt_Recojo";
            this.Txt_Recojo.Size = new System.Drawing.Size(277, 26);
            this.Txt_Recojo.TabIndex = 20;
            // 
            // Txt_Partida
            // 
            this.Txt_Partida.Location = new System.Drawing.Point(226, 108);
            this.Txt_Partida.Name = "Txt_Partida";
            this.Txt_Partida.Size = new System.Drawing.Size(277, 26);
            this.Txt_Partida.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(570, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "DIRECCIÓN DE LLEGADA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "DIRECCIÓN DE PARTIDA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nª ORDEN DE RECOJO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "FECHA DE TRASLADO: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "FECHA DE EMISIÓN: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_ID_1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(58, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 179);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REMITENTE";
            // 
            // Txt_ID_1
            // 
            this.Txt_ID_1.Location = new System.Drawing.Point(210, 46);
            this.Txt_ID_1.Name = "Txt_ID_1";
            this.Txt_ID_1.Size = new System.Drawing.Size(85, 26);
            this.Txt_ID_1.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.button1.Location = new System.Drawing.Point(58, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 40);
            this.button1.TabIndex = 28;
            this.button1.Text = "Formulario Remitente";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(156, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "ID:";
            // 
            // Lbl_DATOS
            // 
            this.Lbl_DATOS.AutoSize = true;
            this.Lbl_DATOS.Font = new System.Drawing.Font("Rockwell Condensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DATOS.Location = new System.Drawing.Point(724, 19);
            this.Lbl_DATOS.Name = "Lbl_DATOS";
            this.Lbl_DATOS.Size = new System.Drawing.Size(236, 33);
            this.Lbl_DATOS.TabIndex = 27;
            this.Lbl_DATOS.Text = "GUÍA DE DESPACHO";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Btn_Actualizar);
            this.groupBox6.Controls.Add(this.Dgv_Cliente);
            this.groupBox6.Location = new System.Drawing.Point(12, 751);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1959, 586);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Vista Cliente";
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Actualizar.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.ACTUALIZAR_V4;
            this.Btn_Actualizar.Location = new System.Drawing.Point(1696, 89);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(116, 78);
            this.Btn_Actualizar.TabIndex = 5;
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Dgv_Cliente
            // 
            this.Dgv_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Cliente.Location = new System.Drawing.Point(18, 54);
            this.Dgv_Cliente.Name = "Dgv_Cliente";
            this.Dgv_Cliente.RowHeadersWidth = 51;
            this.Dgv_Cliente.RowTemplate.Height = 24;
            this.Dgv_Cliente.Size = new System.Drawing.Size(1634, 480);
            this.Dgv_Cliente.TabIndex = 17;
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.Btn_Ayuda.Image = global::Capa_Vista_AmmyCatun.Properties.Resources.AYUDA_V4;
            this.Btn_Ayuda.Location = new System.Drawing.Point(329, 101);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(112, 78);
            this.Btn_Ayuda.TabIndex = 6;
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            this.Btn_Ayuda.Click += new System.EventHandler(this.Btn_Ayuda_Click);
            // 
            // Transporte_Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Lbl_DATOS);
            this.Name = "Transporte_Vehiculos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox Txt_ID_2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox Txt_Destino;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox Cmb_Forma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Traslado;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Emision;
        private System.Windows.Forms.TextBox Txt_LLegada;
        private System.Windows.Forms.TextBox Txt_Recojo;
        private System.Windows.Forms.TextBox Txt_Partida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_ID_1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Lbl_DATOS;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button Btn_Actualizar;
        private System.Windows.Forms.DataGridView Dgv_Cliente;
        private System.Windows.Forms.TextBox Txt_id_Vehiculo;
        private System.Windows.Forms.Label lbl_Id_Vehiculo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Guia;
        private System.Windows.Forms.Button Btn_Ayuda;
    }
}