using AplicativoDeComida.Controller;
using System.Text.RegularExpressions;
using AplicativoDeComida.Modelos;
using AplicativoDeComida.Data;

namespace AplicativoDeComida.Services
{
    public class GerenciamentoDeCliente
    {
        private readonly AppDbContext _context;

        private ClienteRepositoryMySQL _clienteRepository; // Corrija o nome aqui

        public GerenciamentoDeCliente(AppDbContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepositoryMySQL(_context); // Passe o contexto para o construtor
        }

        // ... outros métodos do GerenciamentoDeCliente
        public void inserirNovoCliente(Cliente cliente)
        {
            string nome;
            string email;
            string senha;

            while (true)
            {
                Console.WriteLine("Digite seu nome");
                nome = Console.ReadLine();
                while (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("Nome não pode estar vazio! Digite novamente:");
                    nome = Console.ReadLine();
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Digite seu Email");
                email = Console.ReadLine();
                while (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email não pode estar vazio! Digite novamente:");
                    email = Console.ReadLine();
                }

                if (_clienteRepository.ExisteNaBaseDeDados("Cliente", "email", email) != null)
                    Console.WriteLine("Email já registrado");
                else
                    break; // Se o e-mail não estiver registrado, sai do loop
            }

            Console.WriteLine("Digite sua senha"); //Inserir Senha 1
            senha = Console.ReadLine();

            while (string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Senha inválida! Digite novamente:");
                senha = Console.ReadLine();
            }

            try
            {
                cliente.Nome = nome;
                cliente.Email = email;
                cliente.Senha = senha;

                _clienteRepository.Inserir(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar cliente: " + ex.Message);
                throw;
            }
        }

        static bool ValidaEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public class AutenticacaoCliente
        {
            private readonly ClienteRepositoryMySQL _clienteRepository;

            public AutenticacaoCliente(AppDbContext context)
            {
                _clienteRepository = new ClienteRepositoryMySQL(context);
            }

            public Cliente ValidarCliente()
            {
                string email, senha;
                Cliente cliente = null;

                Console.WriteLine("Digite seu e-mail:");
                email = Console.ReadLine();

                Console.WriteLine("Digite sua senha:");
                senha = Console.ReadLine();



                // Verifica se o cliente existe na base de dados com o email fornecido
                cliente = _clienteRepository.ExisteNaBaseDeDados("Cliente", "email", email);

                if (cliente == null)
                {
                    Console.WriteLine("E-mail não cadastrado!");
                    return null;
                }

                if (cliente.Senha != senha)
                {
                    Console.WriteLine("Senha incorreta!");
                    return null;
                }

                Console.WriteLine("Login bem-sucedido!");
                return cliente;
            }
        }

        public void AtualizarCliente(int id, Cliente cliente)
        {
            _clienteRepository.Atualizar(id, cliente);
        }

        public void ExcluirCliente(int id)
        {
            _clienteRepository.Excluir(id);
        }

        public Cliente ObterClientePorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public List<Cliente> ObterTodosClientes()
        {
            return _clienteRepository.ObterTodos();
        }

        // Outros métodos do GerenciamentoDeClientes conforme necessário
    }

}
