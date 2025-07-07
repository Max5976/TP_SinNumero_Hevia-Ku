namespace TP_SinNumero_Hevia_Ku.Models;

class Integrante {
    public string nombreDeUsuario { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime fechaDeNacimiento { get; set; }
    public List<string> palabrasClaveQueDescriban { get; set; }
    public string logros { get; set; }
    public string opinionProfesional { get; set; }
    public string foto {get; private set;}

    public Integrante (string nombreDeUsuario, string email, string password, DateTime fechaDeNacimiento, string logros, string opinionProfesional, string foto) {
        this.nombreDeUsuario = nombreDeUsuario;
        this.email = email;
        this.password = password;
        this.fechaDeNacimiento = fechaDeNacimiento;
        palabrasClaveQueDescriban = new List<string>();
        this.logros = logros;
        this.opinionProfesional = opinionProfesional;
        this.foto = foto;
    }

        public int ObtenerEdad()
        {
            int anoActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;
            int diaActual = DateTime.Now.Day;

            int anoEdad = anoActual - fechaDeNacimiento.Year;
            if (mesActual < fechaDeNacimiento.Month)
            {
                if(diaActual < fechaDeNacimiento.Day)
                {
                    anoEdad--;
                }
            }
            return anoEdad;
        }

}
