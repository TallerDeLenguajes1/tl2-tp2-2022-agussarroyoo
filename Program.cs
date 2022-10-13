// See https://aka.ms/new-console-template for more information
using NLog;

Logger log = LogManager.GetCurrentClassLogger();

log.Info("Hola, esto es un programa de consola");
log.Debug("Esto es un mensaje de debugueo");

try
{
    System.Console.WriteLine("Cantidad de alumnos a inscribrir: ");
    int cant = Int32.Parse(Console.ReadLine()); 

    List<Alumno> Alumnos = new List<Alumno>();

    int dni, curso;
    string nombre, apellido;

    for (int i = 0; i < cant; i++)
    {   
        System.Console.WriteLine("ALUMNO [" + i  + "]");
        System.Console.WriteLine("Ingrese el nombre: ");
        nombre = Console.ReadLine(); 
        System.Console.WriteLine("Ingrese el apellido: ");
        apellido = Console.ReadLine();
        System.Console.WriteLine("Ingrese el dni: ");
        dni = Int32.Parse(Console.ReadLine());
        System.Console.WriteLine("Ingrese el nro de curso: 1.Atletismo 2.Voley 3.Futbol");
        curso = Int32.Parse(Console.ReadLine());
        Alumnos.Add(new Alumno(i,nombre,apellido,dni,curso));
        System.Console.WriteLine("----------------------------");

    }
}
catch (System.Exception)
{
    
    throw;
}


static class HelperArchivos {
    
    static public void Escribir (string nombreArchivo, string extension,Alumno alum) {
        FileStream archivo = new FileStream(nombreArchivo + extension, FileMode.Create);
        
        StreamWriter escribir = new StreamWriter(archivo);

        
        escribir.WriteLine("Apellido, Nombre, DNI, ID, Curso "); 

        
        string curso;
        switch (alum.Curso) {
            case 1:
                curso = "Atletismo";
            break;
            case 2:
                curso = "Voley";
            break;
            case 3:
                curso = "Futbol";
            break;
            default: 
                curso = "";
            break;
        }
        escribir.WriteLine("{0},{1},{2},{3},{4}", alum.Apellido,alum.Nombre, alum.DNI, alum.ID, curso); 
            

        escribir.Close();
        archivo.Close();
    }

    static public void Limpiar (string nombreArchivo) {
       FileStream archivo = new FileStream(nombreArchivo, FileMode.Create );

        StreamWriter escribir = new StreamWriter(archivo);
        escribir.WriteLine(string.Empty);
    }



}
public class Alumno {
    private int id;
    private string nombre;
    private string apellido;
    private int dni;
    public int Curso;

    public Alumno(int id, string nombre, string ape, int dni, int Curso) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = ape;
        this.dni = dni;
        this.Curso = Curso;
        this.Inscribir();
    }
    
    public void Inscribir() {
        switch (this.Curso) {
            case 1:
                HelperArchivos.Escribir("Atletismo", ".csv", this);
            break;
            case 2:
                HelperArchivos.Escribir("Voley",".csv",this);
            break;
            case 3:
                HelperArchivos.Escribir("Futbol", ".csv", this);
            break;
        }
    }
    public int ID {
        get{
            return id;
        } set{
            id = value;
        }
    }

    public string Nombre {
        get{
            return nombre;
        } set{
            nombre = value;
        }
    }

    public string Apellido {
        get{
            return apellido;
        } set{
            apellido = value;
        }
    }

    public int DNI {
        get{
            return dni;
        } set{
            dni = value;
        }
    }


}