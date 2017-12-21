using System;
using System.Data.SqlClient;   // System.Data.dll 
//using System.Data;           // For:  SqlDbType , ParameterDirection

namespace csharp_db_test
{
    class Program
    {
        static System.Numerics.BigInteger PrivateKey;
        static System.Numerics.BigInteger[] PublicKey;
        static P[] Pressoes;
        static int foo;
        static int fighters;

        private static void keygen_Click()
        {
            Random rnd = new Random();
            byte[] rand = new byte[16];

            //key generation
            do
            {
                rnd.NextBytes(rand);
                PrivateKey = new System.Numerics.BigInteger(rand);
                PrivateKey = System.Numerics.BigInteger.Abs(PrivateKey);
            } while (System.Numerics.BigInteger.GreatestCommonDivisor(PrivateKey, 1000000) != 1);

            PublicKey = new System.Numerics.BigInteger[100];

            for (int i = 0; i < 100; i++)
            {
                rnd.NextBytes(rand);
                PublicKey[i] = new System.Numerics.BigInteger(rand);
                PublicKey[i] = (System.Numerics.BigInteger.Abs(PublicKey[i]) * PrivateKey) + (1000000 * rnd.Next(10, 100));
            }
        }

        static string encrypt(string Valor)
        {
            System.Numerics.BigInteger A;
            System.Numerics.BigInteger.TryParse(Valor, out A);

            System.Numerics.BigInteger t = new System.Numerics.BigInteger(0);

            //A->Enc(A)
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                if (rand.Next(2) == 1)
                    t = t + PublicKey[i];
            }

            return (A + t).ToString();
        }

        static string decrypt(string Valor)
        {
            System.Numerics.BigInteger E;
            System.Numerics.BigInteger.TryParse(Valor, out E);

            System.Numerics.BigInteger M = new System.Numerics.BigInteger(0);

            M = System.Numerics.BigInteger.Remainder(E, PrivateKey);
            return System.Numerics.BigInteger.Remainder(M, 1000000).ToString();
        }

        public static string Click(P[] p)
        {
            System.Numerics.BigInteger[] z = new System.Numerics.BigInteger[10];
            System.Numerics.BigInteger[] y = new System.Numerics.BigInteger[10];

            for (int i = 0; i < 10; i++)
            {
                System.Numerics.BigInteger A;
                System.Numerics.BigInteger.TryParse(p[i].D, out A);
                z[i] = A;

                System.Numerics.BigInteger B;
                System.Numerics.BigInteger.TryParse(p[i].S, out B);
                y[i] = B;
            }

            Console.WriteLine("120 - " + z[0]);
            Console.WriteLine(" 130 - " + z[1]);
            Console.WriteLine(" 132 - " + z[2]);
            Console.WriteLine(" 139 - " + z[3]);
            Console.WriteLine(" 141 - " + z[4]);
            Console.WriteLine(" 128 - " + z[5]);
            Console.WriteLine(" 131 - " + z[6]);
            Console.WriteLine(" 128 - " + z[7]);
            Console.WriteLine(" 140 - " + z[8]);
            Console.WriteLine(" 133 - " + z[9]);

            Console.WriteLine(" 97 - " + y[0]);
            Console.WriteLine(" 92 - " + y[1]);
            Console.WriteLine(" 91 - " + y[2]);
            Console.WriteLine(" 99 - " + y[3]);
            Console.WriteLine(" 92 - " + y[9]);
            Console.WriteLine(" 88 - " + y[4]);
            Console.WriteLine(" 89 - " + y[5]);
            Console.WriteLine(" 95 - " + y[6]);
            Console.WriteLine(" 96 - " + y[7]);
            Console.WriteLine(" 93 - " + y[8]);


            System.Numerics.BigInteger g = z[0];
            System.Numerics.BigInteger h = y[0];

            for (int i = 1; i < 10; i++)
            {
                g = g + z[i];
                h = h + y[i];
            }

                        


            Console.WriteLine("1322 - " + g.ToString());
            Console.WriteLine(" 932  - " + h.ToString());


            foo = int.Parse(decrypt(g.ToString()));
            fighters = int.Parse(decrypt(h.ToString()));

            Console.WriteLine(foo + " , " + fighters);

            return null;
        }

        static void Main(string[] args)
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "galocura22.database.windows.net";
                cb.UserID = "samuel.barceloss";
                cb.Password = "AxlRose123";
                cb.InitialCatalog = "IHospital";

                string Dia, Sis;
                Pressoes = new P[10];

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();

                    Submit_Tsql_NonQuery(connection, "2 - Create-Tables",
                       Build_2_Tsql_CreateTables());

                    keygen_Click();

                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Paciente());

                    Dia = encrypt("120");
                    Sis = encrypt("97");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("130");
                    Sis = encrypt("92");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("132");
                    Sis = encrypt("91");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("139");
                    Sis = encrypt("99");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("141");
                    Sis = encrypt("88");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("128");
                    Sis = encrypt("92");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("131");
                    Sis = encrypt("89");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("128");
                    Sis = encrypt("95");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("140");
                    Sis = encrypt("96");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Dia = encrypt("133");
                    Sis = encrypt("93");
                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                       Build_3_Tsql_Insert_Medidor(Dia, Sis));

                    Submit_6_Tsql_SelectEmployees(connection);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Aplicativo Médico");
            Console.ReadKey();

            string aaaaa = Click(Pressoes);

            foo = foo / 10;
            fighters = fighters / 10;

            if (foo < 90 && fighters < 60)
            {
                Console.WriteLine("PRESSÃO BAIXA");
            }
            else
            if (foo < 120 && fighters < 80)
            {
                Console.WriteLine("ARTERIAL NORMAL");
            }
            else
                if ((foo >= 120 && foo < 139) || (fighters >= 80 && fighters < 89))
            {
                Console.WriteLine("PRÉ-HIPERTENSÃO");
            }
            else
                    if ((foo > 139 && foo <= 159) || (fighters > 89 && fighters <= 99))
            {
                Console.WriteLine("HIPERTENSÃO ESTÁGIO 1");
            }
            else
                        if ((foo > 159 && foo <= 179) && (fighters > 100 && fighters <= 109))
            {
                Console.WriteLine("HIPERTENSÃO ESTÁGIO 2");
            }
            else
                            if (foo > 180 || fighters > 110)
            {
                Console.WriteLine("CRISE HIPERTENSIVA");
            }

            Console.WriteLine("View the report output here, then press any key to end the program...");
            Console.ReadKey();
        }

        static string Build_2_Tsql_CreateTables()
        {
            return @"
DROP TABLE IF EXISTS tabMedidor;
DROP TABLE IF EXISTS tabPaciente;  -- Drop parent table last.

CREATE TABLE tabPaciente
(
   PacienteCode  nchar(4)          not null
      PRIMARY KEY,
   PacienteName  nvarchar(128)     not null
);

CREATE TABLE tabMedidor
(
   MedidorGuid    uniqueIdentifier  not null  default NewId()
      PRIMARY KEY,
   Diastolica    varchar(255)     not null,
   Sistolica     varchar(255)     not null,
   PacienteCode  nchar(4)              null
      REFERENCES tabPaciente (PacienteCode)  -- (REFERENCES would be disallowed on temporary tables.)
);
";
        }

        static string Build_3_Tsql_Insert_Paciente()
        {
            return @"
-- The company has these departments.
INSERT INTO tabPaciente
   (PacienteCode, PacienteName)
      VALUES
   ('legl', 'Samuel');
";
        }

        static string Build_3_Tsql_Insert_Medidor(string Diastolica, string Sistolica)
        {
            return @"
INSERT INTO tabMedidor
   (Diastolica, Sistolica, PacienteCode)
      VALUES
   ('" + Diastolica + "', '" + Sistolica + "', 'legl')";
        }

        static string Build_6_Tsql_SelectEmployees()
        {
            return @"
SELECT
      Diastolica,
      Sistolica
   FROM
      tabMedidor";
        }

        static void Submit_6_Tsql_SelectEmployees(SqlConnection connection)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Now, SelectMedidor...");

            string tsql = Build_6_Tsql_SelectEmployees();

            using (var command = new SqlCommand(tsql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int i = 0;

                    while (reader.Read())
                    {
                        string a = reader.GetString(0);
                        string b = reader.GetString(1);

                        P pp = new P(a, b);

                        Pressoes[i] = pp;
                        i++;

                        Console.WriteLine("{0} , {1}",
                           a,
                           b);
                    }
                }
            }
        }

        static void Submit_Tsql_NonQuery(
         SqlConnection connection,
         string tsqlPurpose,
         string tsqlSourceCode,
         string parameterName = null,
         string parameterValue = null
         )
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("T-SQL to {0}...", tsqlPurpose);

            using (var command = new SqlCommand(tsqlSourceCode, connection))
            {
                if (parameterName != null)
                {
                    command.Parameters.AddWithValue(  // Or, use SqlParameter class.
                       parameterName,
                       parameterValue);
                }
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " = rows affected.");
            }
        }
    } // EndOfClass
}

public class P
{
    public string D;
    public string S;

    public P(string d, string s)
    {
        D = d;
        S = s;
    }
}