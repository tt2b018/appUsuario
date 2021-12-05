using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using F5;
using mecanismoTT;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AppUsuario
{
    public partial class Form1 : Form
    {
        private OpenFileDialog selectorDocumentos = new System.Windows.Forms.OpenFileDialog();
        private String imagen = "";
        private String keyAutor = "";
        private String keyReceptor = "";
        String informacionAutor = "";
        String informacionReceptor = "";
        bool eA = false;
        bool eB = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectorDocumentos.Reset();
            selectorDocumentos.Filter = "Imagen JPEG (*.jpg, *.jpeg)|*.jpg; *.jpeg";
            selectorDocumentos.ShowDialog();
            imagen = selectorDocumentos.FileName;
            rutaImagen.Text = imagen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectorDocumentos.Reset();
            selectorDocumentos.Filter = "Llave del Receptor|*.bin";
            selectorDocumentos.ShowDialog();
            keyReceptor = selectorDocumentos.FileName;
            rutaLlaveReceptor.Text = keyReceptor;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(imagen.Length > 0)
            {
                if(keyAutor.Length > 0)
                {
                    extraerInformacion();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado la llave del autor.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign); 
                    //mensajes.Text = mensajes.Text + "No se ha seleccionado la llave del autor." + Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado la imagen.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                // mensajes.Text = mensajes.Text + "No se ha seleccionado la imagen. " + Environment.NewLine;
            }
        }

        public void extraerInformacion()
        {
            byte[] texto;

            texto = Extract.Run(imagen);

            if (texto == null || texto.Length == 0 || (texto.Length != 161 && texto.Length != 321))
            {
                MessageBox.Show("No hay información incrustada en la imagen.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                //mensajes.Text = mensajes.Text + "No hay información incrustada en la imagen." + Environment.NewLine;
            }
            else
            {
                //mensajes.Text = mensajes.Text + "Información encontrada en la imagen." + Environment.NewLine;
                try
                {
                    Descifrador d = new Descifrador(@keyAutor);
                    byte[] infoEmisorBytes = new byte[160];
                    Buffer.BlockCopy(texto, 1, infoEmisorBytes, 0, infoEmisorBytes.Length);
                    informacionAutor = d.descifrar(infoEmisorBytes);
                    //mensajes.Text = mensajes.Text + "Información del autor encontrada." + Environment.NewLine;
                    infoAutor.Text = formato(informacionAutor, 0);

                    if (texto[0] == 1)
                    {
                        if (keyReceptor.Equals(""))
                            MessageBox.Show("No se ha seleccionado la llave del receptor.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        //mensajes.Text = mensajes.Text + "No se ha seleccionado la llave del receptor." + Environment.NewLine;
                        else
                        {
                            Descifrador d2 = new Descifrador(@keyReceptor);
                            byte[] infoReceptorBytes = new byte[160];
                            Buffer.BlockCopy(texto, 161, infoReceptorBytes, 0, infoReceptorBytes.Length);
                            informacionReceptor = d2.descifrar(infoReceptorBytes);
                            //mensajes.Text = mensajes.Text + "Información del receptor encontrada." + Environment.NewLine;
                            infoReceptor.Text = formato(informacionReceptor, 1);
                        }
                    }
                    //mensajes.Text = mensajes.Text + "Extracción terminada." + Environment.NewLine;

                }
                catch
                {
                    if(!File.Exists(imagen))
                    {
                        MessageBox.Show("No se encontró la imagen seleccionada. Intente de nuevo.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    if(!File.Exists(keyAutor) || !File.Exists(keyReceptor))
                    {
                        MessageBox.Show("El archivo que contiene la llave no fue encontrado.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    if(File.Exists(imagen) && File.Exists(keyAutor) && File.Exists(keyReceptor))
                    {
                        MessageBox.Show("Algo salió mal en el proceso de descifrado, verifique e intente de nuevo.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    //mensajes.Text = mensajes.Text + "Algo salió mal en el proceso de descifrado, verifique e intente de nuevo." + Environment.NewLine;
                }

            }
        }

        public String formato(String s, int b)
        {
            String formato = "Fecha: " + s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4,4);
            formato += "\nHora: " + s.Substring(8, 2) + ":" + s.Substring(10, 2) + ":" +s.Substring(12, 2);
            formato += "\nID: " + s.Substring(14, 15);
            formato += "\nUUID: " + s.Substring(29, 36);
            String hashObtenido = s.Substring(65);
            String hashEsperado = HashString(s.Substring(0, 65));
            if(hashObtenido.Equals(hashEsperado))
            {
                if(b == 0)
                {
                    estadoA.ForeColor = System.Drawing.Color.Green;
                    estadoA.Text = "Información íntegra";
                    eA = true;
                }
                else
                {
                    estadoB.ForeColor = System.Drawing.Color.Green;
                    estadoB.Text = "Información íntegra";
                    eB = true;
                }
            }
            else
            {
                if(b == 0)
                {
                    estadoA.ForeColor = Color.FromArgb(180, 25, 25);
                    estadoA.Text = "Información corrupta";
                    eA = false;
                }
                else
                {
                    estadoB.ForeColor = Color.FromArgb(180, 25, 25);
                    estadoB.Text = "Información corrupta";
                    eB = false;
                }
            }
            return formato;
        }
        public String HashString(String s)
        {
            using SHA256 sha = SHA256.Create();
            byte[] sBytes = Encoding.ASCII.GetBytes(s);
            String hash = BitConverter.ToString(sha.ComputeHash(sBytes)).Replace("-", "");
            sha.Clear();
            sha.Dispose();
            return hash;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           // mensajes.Text = "";
            infoReceptor.Text = "";
            infoAutor.Text = "";
            rutaImagen.Text = "";
            rutaLlaveAutor.Text = "";
            rutaLlaveReceptor.Text = "";
            imagen = "";
            keyAutor = "";
            keyReceptor = "";
            estadoA.Text = "";
            estadoB.Text = "";
        }

        private void msgCargaLlaves_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAutorKey_Click(object sender, EventArgs e)
        {
            selectorDocumentos.Reset();
            selectorDocumentos.Filter = "Key |*.bin";
            selectorDocumentos.ShowDialog();
            keyAutor = selectorDocumentos.FileName;
            rutaLlaveAutor.Text = keyAutor;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF|*.pdf";
            saveFileDialog.Title = "Seleccione la ruta para guardar el reporte.";
            saveFileDialog.FileName = "Reporte";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //if (resultado == DialogResult.OK && !string.IsNullOrWhiteSpace(selectorCarpeta.SelectedPath))
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String dia = DateTime.Now.ToString("dd"), mes = DateTime.Now.ToString("MM"), anio = DateTime.Now.ToString("yyyy");
                String[] meses = new String[] { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiempre", "octubre", "noviembre", "diciembre" };
                
                iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fuenteHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 13, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteTextoNegritas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fuenteTexto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Document doc = new Document(PageSize.LETTER, 60, 60, 30, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Path.GetFullPath(saveFileDialog.FileName), FileMode.Create));

                doc.Open();
                
                PdfPTable tablaHeader = new PdfPTable(2);
                tablaHeader.WidthPercentage = 100;
                tablaHeader.SetWidths(new float[] { 60, 50 });

                PdfPCell org = new PdfPCell(new Phrase("Secretaría de Seguridad Ciudadana", fuenteHeader));
                org.BorderWidth = 0;
                org.PaddingBottom = 5;
                org.PaddingLeft = 5;
                org.VerticalAlignment = 2;
                org.PaddingTop = 30;
                
                tablaHeader.AddCell(org);

                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance("logo_policia.png");
                gif.ScalePercent(10);

                PdfPCell img = new PdfPCell(gif);
                img.BorderWidth = 0;
                img.PaddingBottom = 25;
                img.PaddingLeft = 5;
                img.HorizontalAlignment = 2; 

                tablaHeader.AddCell(img);
                doc.Add(tablaHeader);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                Paragraph fecha = new Paragraph(new Phrase("Fecha de generación: " + dia + " de " + meses[int.Parse(mes) - 1] + " del " + anio + ".", fuenteTexto));
                fecha.Alignment = 2;
                doc.Add(fecha);

                Paragraph folio = new Paragraph(new Phrase("Folio: XX-XXX", fuenteTexto));
                folio.Alignment = 2;
                doc.Add(folio);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                
                Paragraph titulo = new Paragraph(new Phrase("Reporte de Extracción de Información", fuenteTitulo));
                titulo.Alignment = 1;
                doc.Add(titulo);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                Paragraph tituloAutor = new Paragraph(new Phrase("Información del autor", fuenteTitulo));
                tituloAutor.SpacingAfter = 15;
                doc.Add(tituloAutor);

                
                PdfPTable tablaAutor = new PdfPTable(2);
                tablaAutor.WidthPercentage = 100;
                tablaAutor.SetWidths(new float[] { 40, 60 });

                PdfPCell estadoAutorLbl = new PdfPCell(new Phrase("Estado de la información", fuenteTextoNegritas));
                estadoAutorLbl.BorderWidth = 1;
                estadoAutorLbl.PaddingBottom = 5;
                estadoAutorLbl.PaddingLeft = 5;
                tablaAutor.AddCell(estadoAutorLbl);

                PdfPCell estadoAutor = new PdfPCell();

                if (eA)
                {
                    estadoAutor = new PdfPCell(new Phrase("Íntegro", fuenteTexto));
                }
                else
                {
                    estadoAutor = new PdfPCell(new Phrase("Corrupto", fuenteTexto));
                }
                estadoAutor.BorderWidth = 1;
                estadoAutor.PaddingBottom = 5;
                estadoAutor.PaddingLeft = 5;
                tablaAutor.AddCell(estadoAutor);

                PdfPCell fechaAutorLbl = new PdfPCell(new Phrase("Fecha de creación", fuenteTextoNegritas));
                fechaAutorLbl.BorderWidth = 1;
                fechaAutorLbl.PaddingBottom = 5;
                fechaAutorLbl.PaddingLeft = 5;
                tablaAutor.AddCell(fechaAutorLbl);

                PdfPCell fechaAutor = new PdfPCell(new Phrase(informacionAutor.Substring(0, 2) + "/" + informacionAutor.Substring(2, 2) + "/" + informacionAutor.Substring(4, 4), fuenteTexto));
                fechaAutor.BorderWidth = 1;
                fechaAutor.PaddingBottom = 5;
                fechaAutor.PaddingLeft = 5;
                tablaAutor.AddCell(fechaAutor);

                PdfPCell horaAutorLbl = new PdfPCell(new Phrase("Hora de creación", fuenteTextoNegritas));
                horaAutorLbl.BorderWidth = 1;
                horaAutorLbl.PaddingBottom = 5;
                horaAutorLbl.PaddingLeft = 5;
                tablaAutor.AddCell(horaAutorLbl);

                PdfPCell horaAutor = new PdfPCell(new Phrase(informacionAutor.Substring(8, 2) + ":" + informacionAutor.Substring(10, 2) + ":" + informacionAutor.Substring(12, 2) + " hrs.", fuenteTexto));
                horaAutor.BorderWidth = 1;
                horaAutor.PaddingBottom = 5;
                horaAutor.PaddingLeft = 5;
                tablaAutor.AddCell(horaAutor);

                PdfPCell uuidAutorLbl = new PdfPCell(new Phrase("UUID del equipo", fuenteTextoNegritas));
                uuidAutorLbl.BorderWidth = 1;
                uuidAutorLbl.PaddingBottom = 5;
                uuidAutorLbl.PaddingLeft = 5;
                tablaAutor.AddCell(uuidAutorLbl);

                PdfPCell uuidAutor = new PdfPCell(new Phrase(informacionAutor.Substring(29, 36), fuenteTexto));
                uuidAutor.BorderWidth = 1;
                uuidAutor.PaddingBottom = 5;
                uuidAutor.PaddingLeft = 5;
                tablaAutor.AddCell(uuidAutor);

                PdfPCell idAutorLbl = new PdfPCell(new Phrase("Número de serie del equipo", fuenteTextoNegritas));
                idAutorLbl.BorderWidth = 1;
                idAutorLbl.PaddingBottom = 5;
                idAutorLbl.PaddingLeft = 5;
                tablaAutor.AddCell(idAutorLbl);

                PdfPCell idAutor = new PdfPCell(new Phrase(informacionAutor.Substring(14, 15), fuenteTexto));
                idAutor.BorderWidth = 1;
                idAutor.PaddingBottom = 5;
                idAutor.PaddingLeft = 5;
                tablaAutor.AddCell(idAutor);
                doc.Add(tablaAutor);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                if (informacionReceptor.Length > 0) {

                    Paragraph tituloReceptor = new Paragraph(new Phrase("Información del receptor", fuenteTitulo));
                    tituloReceptor.SpacingAfter = 15;
                    doc.Add(tituloReceptor);

                    PdfPTable tablaReceptor = new PdfPTable(2);
                    tablaReceptor.WidthPercentage = 100;
                    tablaReceptor.SetWidths(new float[] { 40, 60 });

                    PdfPCell estadoReceptorLbl = new PdfPCell(new Phrase("Estado de la información", fuenteTextoNegritas));
                    estadoReceptorLbl.BorderWidth = 1;
                    estadoReceptorLbl.PaddingBottom = 5;
                    estadoReceptorLbl.PaddingLeft = 5;
                    tablaReceptor.AddCell(estadoReceptorLbl);

                    PdfPCell estadoReceptor = new PdfPCell();

                    if (eA)
                    {
                        estadoReceptor = new PdfPCell(new Phrase("Íntegro", fuenteTexto));
                    }
                    else
                    {
                        estadoReceptor = new PdfPCell(new Phrase("Corrupto", fuenteTexto));
                    }
                    estadoReceptor.BorderWidth = 1;
                    estadoReceptor.PaddingBottom = 5;
                    estadoReceptor.PaddingLeft = 5;
                    tablaReceptor.AddCell(estadoReceptor);

                    PdfPCell fechaReceptorLbl = new PdfPCell(new Phrase("Fecha de creación", fuenteTextoNegritas));
                    fechaReceptorLbl.BorderWidth = 1;
                    fechaReceptorLbl.PaddingBottom = 5;
                    fechaReceptorLbl.PaddingLeft = 5;
                    tablaReceptor.AddCell(fechaReceptorLbl);

                    PdfPCell fechaReceptor = new PdfPCell(new Phrase(informacionReceptor.Substring(0, 2) + "/" + informacionReceptor.Substring(2, 2) + "/" + informacionReceptor.Substring(4, 4), fuenteTexto));
                    fechaReceptor.BorderWidth = 1;
                    fechaReceptor.PaddingBottom = 5;
                    fechaReceptor.PaddingLeft = 5;
                    tablaReceptor.AddCell(fechaReceptor);

                    PdfPCell horaReceptorLbl = new PdfPCell(new Phrase("Hora de creación", fuenteTextoNegritas));
                    horaReceptorLbl.BorderWidth = 1;
                    horaReceptorLbl.PaddingBottom = 5;
                    horaReceptorLbl.PaddingLeft = 5;
                    tablaReceptor.AddCell(horaReceptorLbl);

                    PdfPCell horaReceptor = new PdfPCell(new Phrase(informacionReceptor.Substring(8, 2) + ":" + informacionReceptor.Substring(10, 2) + ":" + informacionReceptor.Substring(12, 2) + " hrs.", fuenteTexto));
                    horaReceptor.BorderWidth = 1;
                    horaReceptor.PaddingBottom = 5;
                    horaReceptor.PaddingLeft = 5;
                    tablaReceptor.AddCell(horaReceptor);

                    PdfPCell uuidReceptorLbl = new PdfPCell(new Phrase("UUID del equipo", fuenteTextoNegritas));
                    uuidReceptorLbl.BorderWidth = 1;
                    uuidReceptorLbl.PaddingBottom = 5;
                    uuidReceptorLbl.PaddingLeft = 5;
                    tablaReceptor.AddCell(uuidReceptorLbl);

                    PdfPCell uuidReceptor = new PdfPCell(new Phrase(informacionReceptor.Substring(29, 36), fuenteTexto));
                    uuidReceptor.BorderWidth = 1;
                    uuidReceptor.PaddingBottom = 5;
                    uuidReceptor.PaddingLeft = 5;
                    tablaReceptor.AddCell(uuidReceptor);

                    PdfPCell idReceptorLbl = new PdfPCell(new Phrase("Número de serie del equipo", fuenteTextoNegritas));
                    idReceptorLbl.BorderWidth = 1;
                    idReceptorLbl.PaddingBottom = 5;
                    idReceptorLbl.PaddingLeft = 5;
                    tablaReceptor.AddCell(idReceptorLbl);

                    PdfPCell idReceptor = new PdfPCell(new Phrase(informacionReceptor.Substring(14, 15), fuenteTexto));
                    idReceptor.BorderWidth = 1;
                    idReceptor.PaddingBottom = 5;
                    idReceptor.PaddingLeft = 5;
                    tablaReceptor.AddCell(idReceptor);

                    doc.Add(tablaReceptor);

                }


                doc.Close();
                writer.Close();

                ProcessStartInfo pi = new ProcessStartInfo(Path.GetFullPath(saveFileDialog.FileName));
                pi.Arguments = Path.GetFileName(Path.GetFullPath(saveFileDialog.FileName));
                pi.UseShellExecute = true;
                pi.WindowStyle = ProcessWindowStyle.Normal;
                pi.Verb = "OPEN";
                Process proc = new Process();
                proc.StartInfo = pi;
                proc.Start();
            }

        }
    }
}
