using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaExamenP3
{
    public static class Constants
    {
        public const string DatabaseFilename = "AGCharactersSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Abrir la base de datos en modo lectura/escritura
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Crear la base de datos si no existe
            SQLite.SQLiteOpenFlags.Create |
            // Habilitar el acceso a la base de datos multi-hilo
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
    }
}
