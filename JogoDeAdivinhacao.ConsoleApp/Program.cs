using System.Threading.Channels;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero = ObterNumeroAleatorio();

            int pontuacao = 1000;

            int qtdeChute = 1;

            ExibirTitulo("Bem vindo ao jogo de adivinhação!");
            int nivel = EscolherNivel();

            nivel = ValidarNivel(nivel);

            int tentativas = ObterTentativas(nivel);

            Console.WriteLine($"Tentativas 1 de {tentativas}.");
            Console.WriteLine("------------------------------------");
            int chute = ObterChute(qtdeChute);

            while (chute != numero && tentativas > 0 || chute == numero && tentativas > 0)
            {
                pontuacao = CalcularPontos(numero, pontuacao, chute);
                bool jogadorGanhou = AvaliarChutes(numero, pontuacao, tentativas, chute);

                if (jogadorGanhou) break;

                qtdeChute++;
                tentativas--;

                Console.WriteLine();
                Console.WriteLine($"Tentativas 1 de {tentativas}.");
                Console.WriteLine("------------------------------------");
                chute = ObterSegundoChute(qtdeChute);
            }
        }

        private static int ObterNumeroAleatorio()
        {
            Random numeroAleatorio = new Random();

            int numero = numeroAleatorio.Next(1, 20);
            return numero;
        }

        private static int ObterSegundoChute(int qtdeChute)
        {
            int chute;
            Console.Write($"Qual o seu {qtdeChute}o Chute? ");
            chute = int.Parse(Console.ReadLine());
            return chute;
        }

        private static bool AvaliarChutes(int numero, int pontuacao, int tentativas, int chute)
        {
            if (chute > numero)
            {
                Console.WriteLine("O seu chute foi maior que o número secreto!");
                Console.WriteLine($"Você fez: {pontuacao} pontos");
                Console.WriteLine();
                
            }
            else if (chute < numero)
            {
                Console.WriteLine("O seu chute foi menor que o número secreto!");
                Console.WriteLine($"Você fez: {pontuacao} pontos");
                Console.WriteLine();
            }
            else if (chute == numero)
            {
                tentativas--;
                Console.WriteLine("Parabéns, você acertou!");
                return true;
            }

            return false;
        }

        private static int CalcularPontos(int numero, int pontuacao, int chute)
        {
            int pontos = (chute - numero) / 2;

            if (pontos < 0)
            {
                pontos = pontos * -1;
            }

            pontuacao -= pontos;
            return pontuacao;
        }

        private static int ObterChute(int qtdeChute)
        {
            Console.Write($"Qual o seu {qtdeChute}o chute? ");
            int chute = int.Parse(Console.ReadLine());
            return chute;
        }

        private static int ObterTentativas(int nivel)
        {
            int tentativas = 0;

            switch (nivel)
            {
                case 1:
                    tentativas = 15;
                    break;
                case 2:
                    tentativas = 10;
                    break;
                case 3:
                    tentativas = 5;
                    break;
            }

            return tentativas;
        }

        private static int ValidarNivel(int nivel)
        {
            while (nivel > 3)
            {
                Console.WriteLine();
                Console.WriteLine("Escolha um dos três niveis apresentados");
                nivel = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            return nivel;
        }

        private static int EscolherNivel()
        {
            Console.Write("Escolha o nível de dificuldade:\n 1 - Fácil, 2 - Médio, 3 - Difícil \n Escolha: ");
            int nivel = int.Parse(Console.ReadLine());
            return nivel;
        }


        private static void ExibirTitulo(string mensagem)
        {
            for (int i = 0; i < mensagem.Length + 4; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            Console.WriteLine($"* {mensagem} *");

            for (int i = 0; i < mensagem.Length + 4; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
