using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ADO.DB_e_MYSQL
{
    class Program
    {
        private static string _connectionString = "Server=127.0.0.1;Database=demosnet;Uid=root;Pwd=root;";
        private static MySqlConnection db = new MySqlConnection(_connectionString);
        static void Main(string[] args)
        {
            try
            {
                db.Open();
                ConsoleKeyInfo KeyPressed;
                do
                {
                    PrintMenu();
                    KeyPressed = Console.ReadKey();

                    switch (KeyPressed.Key)
                    {
                        case ConsoleKey.F1:
                            ListarTodos();
                            break;

                        case ConsoleKey.F2:
                            ListarPorCodigo();
                            break;

                        case ConsoleKey.F3:
                            ListarPorCodigoOuDescricao();
                            break;

                        case ConsoleKey.F4:
                            Novo();
                            break;

                        case ConsoleKey.F5:
                            Editar();
                            break;

                        case ConsoleKey.F6:
                            Eliminar();
                            break;

                        default:
                            if (KeyPressed.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Console.WriteLine(">> Super Produtos -- Bye! Bye!");
                            }
                            break;
                    }
                } while (KeyPressed.Key != ConsoleKey.Escape);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro:{ex.Message}");
            }
            finally
            {
                if (db.State == System.Data.ConnectionState.Open)
                {
                    db.Close();
                }
                Console.WriteLine("\n\nPremir tecla para continuar...");
                Console.ReadKey();

            }

        }


        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("********** Super Produtos **********\n");
            Console.WriteLine("F1 - Listar todos os registos");
            Console.WriteLine("F2 - Procurar por código");
            Console.WriteLine("F3 - Procurar por código ou descrição");
            Console.WriteLine("F4 - Inserir novo");
            Console.WriteLine("F5 - Editar");
            Console.WriteLine("F6 -  Eliminar");
            Console.WriteLine("Esc - Terminar");

        }

        private static void ListarTodos()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n********** SUPER PRODUTOS >> Listar Todos ***********\n");

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db;
            cmd.CommandText = "SELECT * FROM produtos order by codigos";
            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                Console.WriteLine("Id\tCódigo\t\tDescrição");

                while (dr.Read())
                {
                    Console.WriteLine($"{dr["produtoid"]}\t{dr["codigo"]}\t\t{dr["descricao"]}");
                }
            }
            else   
            {
                Console.WriteLine(">>Não existem registos!");

            }
            if(!dr.IsClosed)
            {
                dr.Close();
            }
            Console.WriteLine("\n\nPremir tecla para continuar....");
            Console.ReadKey();

        }

        private static void ListarPorCodigo()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n********** SUPER PRODUTOS >> Listar por Código **********\n");


            Console.Write("Código a procurar >> ");
            string strLido = Console.ReadLine();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db;

            cmd.CommandText = " SELECT * FROM produtos where codigo=@codigo order by codigo";

            cmd.Parameters.Add("@codigo", MySqlDbType.String).Value = strLido;

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Console.WriteLine("\nId\tCódigo\t\tDescrição");
                
                while(dr.Read())
                {
                    Console.WriteLine($"{dr["produtoid"]}\t{dr["codigo"]}\t\t{dr["descricao"]}");
                }

            }
            else
            {
                Console.WriteLine("\n>>Não existem registos!");
            }
            
            if(!dr.IsClosed)
            {
                dr.Close();
            }
            Console.WriteLine("\n\nPremir tecla para continuar....");
            Console.ReadKey();
        } 

        private static void ListarPorCodigoOuDescricao()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n********** SUPER PRODUTOS >> Listar por Código ou Descrição **********\n");
            Console.Write("Código ou descrição a procurar >>");
            string strCodLido = Console.ReadLine();


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db;
            cmd.CommandText = "SELECT * FROM produtos where codigo=@codigo or descricao like @descricao order by codigo ";
            cmd.Parameters.Add("@codigo", MySqlDbType.String).Value = strCodLido;
            cmd.Parameters.Add("@descricao", MySqlDbType.String).Value = $"%{strCodLido}%";

            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                Console.WriteLine("\nId\tCódigo\t\tDescrição");


                while (dr.Read())
                {
                    Console.WriteLine($"{dr["produtoid"]}\t{dr["codigo"]}\t\t{dr["descricao"]}");
                }
            
            }
            else
            {
                Console.WriteLine("\n>>Não existem registos!");
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            Console.WriteLine("\n\nPremir tecla para continuar....");
            Console.ReadKey();

        }
        private static void Novo()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n********** SUPER PRODUTOS >> Novo ***********\n");

            Console.Write("Código de Produto >> ");
            string strCodigoLido = Console.ReadLine();

            Console.Write("Descrição de Produto >> ");
            string strDescricaoLido = Console.ReadLine();

            MySqlCommand cmdInsert = new MySqlCommand();
            cmdInsert.Connection = db;
            cmdInsert.CommandText = "Insert into produtos (codigo, descricao) values (@codigo, @descricao)";

            cmdInsert.Parameters.Add("@codigo", MySqlDbType.String).Value = strCodigoLido;
            cmdInsert.Parameters.Add("@descricao", MySqlDbType.String).Value = strDescricaoLido;

            int recAfectados = cmdInsert.ExecuteNonQuery();
            Console.WriteLine($"\n Foram Inseridos {recAfectados} registos!");
            
            Console.WriteLine("\n\nPremir tecla para continuar....");
            Console.ReadKey();

        }
        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n********** SUPER PRODUTOS >> Editar **********\n");

            Console.Write("Código a editar >>");
            string strCodigoLido = Console.ReadLine();
        }



    }

}
    

