using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploGrilla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Llamamos al metodo
            CrearGrillaAlumnos();

            //Llamamos al metodo Cargar Listado Alumnos
            CargarListadoAlumnos();

        }

        //sera de uso interno del formulario,
        //su visualizacion debe ser private
        //este metodo se encarga de encapsular la logica
        // de diseño y creacion de la grilla ( Listado Alumnos )
        private void CrearGrillaAlumnos() {
            //tipo va hacer la columna 
            var nombre = new DataGridViewTextBoxColumn();
            var apellido = new DataGridViewTextBoxColumn();
            var curso = new DataGridViewTextBoxColumn();


            //grilla se añaden las columnas, por meido de un arreglo
            //haciendo uso de DAtagRidViewColumn[]

            dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] {
                    nombre,     //Columna 0
                    apellido,   //Columna 1
                    curso       //Columna 2
                    //-.........
                });

            // Propiedades a cada columna
            //accediendo por su indice ( comienza desde cero )
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[0].HeaderText = "Nombre Alumno";


            dataGridView1.Columns[1].Name = "Apellido";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[1].HeaderText = "Apellido Alumno";

            dataGridView1.Columns[2].Name = "Curso";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Curso Alumno";

        }

        //los metodos void, son aquellos que no retornan valor.
        //solo generan una accion en el proceso
        private void CargarListadoAlumnos() {

           
            //como el metodo BuscarAlumnos(), retorna un List<con arreglos de string>
            // debemos crear la variable que recibirá dicho objeto
            List<string[]> listadoAlumnos = BuscarAlumnos();


            //el metodo Add de Rows, puede recibir un objeto
            // foreach, es  un iterador.
            //iterará al listao alumnos y por cada valor ( lista )
            // almacenará su resultsado en la variable de tipo string[] alumno
            // es decir, cada vuelta de la iteracion, tendra a un alumno
            //entonces si hay cuatro alumnos, dara cuatro vueltas
            foreach (string[] elAlumno in listadoAlumnos) {

                //add recibe un objeto string[] 
                //que en este caso es alumno ( por cada vuelta )
                dataGridView1.Rows.Add( elAlumno );

            }
            


        }

        //retornara una lista de tipo arreglos de string
        private List<string[]> BuscarAlumnos() {
            //CRea una lista que soportará arreglos
            //List genera una interfaz que implementa el tipo de dato 
            //expuesto < tipo dato >
            //new List< tipo de dato >, genera el objeto alumnos
            // List<string[]> alumnos ( crea un tipo de dato ( que se llamara alumno), de tipo List que soporta arreglos de string)
            // = new List<string[]>(); crea un objeto ( instancia) que detemrina 
            //que lo que soportará alumnos sea una instancia de un objeto de tipo 
            //lista y que soporte arreglos de string

            List<string[]> alumnos = new List<string[]>();

            //Add, agrega una lista a la variable tipo LIST alumnos
            // espera Add un obejto que tenga la misma caracterista de la definicion
            // es decir un array de string
           //new string[]{"le", "paso", "los", "valores", "del", "arreglo"}
            alumnos.Add(new string[]{ "Bastian", "Olavarria", "segundo año"});
            alumnos.Add(new string[] { "Gerardo", "Silva", "segundo año" });
            alumnos.Add(new string[] { "Felipe", "Uribe", "segundo año" });
            alumnos.Add(new string[] { "Luciano", "Alvares", "segundo año" });

            //para retornar un valor,
            //se requiere que en la implementacion del metodo,
            //se indique el tipo de retorno
            return alumnos;

        }

        private void SeleccionaAlumno(object sender, DataGridViewCellMouseEventArgs e)
        {
            // el objeto que recibe como prarmetro "e"
            //trae informacion del evento que se genero sobre la grilla
            //e.RowIndex
            //tiene informacion sobre que row se genero el evento
            // comenzando la primera fila en cero
            // y el encabezado es -1
            if (e.RowIndex >= 0) {// solo capturo clik sobre grilla
                // captura el valor de la celda cero de la grilla, segun
                //rowIndex generado, al evento click
                //dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()
                //dataGridView1 = corresponde a al grilla
                //Rows[] es un arreglo de filas comenzando de cero ( listado de los alumnos , en la grilla)
                //[ e.RowIndex ], es el numero de la fila la cual se genero el evento click.
                //Cells[] = corresponde a la celda, que necesitan obtener informacion
                //Value, como al crear grilla se instancia un objeto, value solo captura la perte del valor de dicho objeto ( para la celda )
                //toString() convierte en string

                //la variable nombre, almacenara el registro o valor
                 //que este en la celda cero de la fila cliqueada
                string nombre = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                //el valor de la variable nombre
                //lo asignamos a la caja de texto txtNombre.Text
                txtNombre.Text = nombre;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
