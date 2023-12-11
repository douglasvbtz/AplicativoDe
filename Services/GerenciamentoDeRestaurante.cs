using AplicativoDeComida.Controller;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;

namespace AplicativoDeComida.Services
{
    public class GerenciamentoDeRestaurante
    {
        private readonly AppDbContext _context;

        private RestauranteRepositoryMySQL _restauranteRepository;

        public GerenciamentoDeRestaurante(AppDbContext context)
        {
            _context = context;
            _restauranteRepository = new RestauranteRepositoryMySQL(_context);
        }

        public void CriarRestaurante(Restaurante restaurante)
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

                if (_restauranteRepository.ExisteNaBaseDeDados("Restaurante", "email", email) != null)
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
                restaurante.Nome = nome;
                restaurante.email = email;
                restaurante.senha = senha;
                _restauranteRepository.Inserir(restaurante);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar cliente: " + ex.Message);
                throw;
            }
        }

        public class AutenticacaoRestaurante
        {
            private readonly RestauranteRepositoryMySQL _restauranteRepositoryMySQL;

            public AutenticacaoRestaurante(AppDbContext context)
            {
                _restauranteRepositoryMySQL = new RestauranteRepositoryMySQL(context);
            }

            public Restaurante ValidarRestaurante()
            {
                string email, senha;
                Restaurante restaurante = null;

                Console.WriteLine("Digite seu e-mail:");
                email = Console.ReadLine();

                Console.WriteLine("Digite sua senha:");
                senha = Console.ReadLine();

                // Verifica se o cliente existe na base de dados com o email fornecido
                restaurante = _restauranteRepositoryMySQL.ExisteNaBaseDeDados("Cliente", "email", email);

                if (restaurante == null)
                {
                    Console.WriteLine("E-mail não cadastrado!");
                    return null;
                }

                if (restaurante.senha != senha)
                {
                    Console.WriteLine("Senha incorreta!");
                    return null;
                }

                Console.WriteLine("Login bem-sucedido!");
                return restaurante;
            }
        }


        public void AtualizarRestaurante(int id, Restaurante restaurante)
        {
            _restauranteRepository.Atualizar(id, restaurante);
        }

        public void ExcluirRestaurante(int id)
        {
            _restauranteRepository.Excluir(id);
        }

        public Restaurante ObterRestaurantePorId(int id)
        {
            return _restauranteRepository.ObterPorId(id);
        }


        public List<Restaurante> ObterTodosRestaurantes()
        {
            var restaurantes = _restauranteRepository.ObterTodos();

            if (restaurantes != null && restaurantes.Any())
            {
                Console.WriteLine("Lista de restaurantes disponíveis:");
                foreach (var restaurante in restaurantes)
                {
                    Console.WriteLine($"ID: {restaurante.RestauranteId} - Nome: {restaurante.Nome}");

                }
            }
            else
            {
                Console.WriteLine("Nenhum restaurante disponível no momento.");
            }

            return restaurantes;
        }


        // Outros métodos do GerenciamentoDeRestaurante conforme necessário
    }
}
