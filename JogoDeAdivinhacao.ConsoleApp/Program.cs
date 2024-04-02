using System.Threading.Channels;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random numeroAleatorio = new Random();

            int numero = numeroAleatorio.Next(1, 20);   

            int pontuacao = 1000;

            int qtdeChute = 1;

            string mensagem = "Bem vindo ao jogo de adivinhação!";
            
            for(int i = 0; i < mensagem.Length + 4; i++)
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

            
            Console.Write("Escolha o nível de dificuldade:\n 1 - Fácil, 2 - Médio, 3 - Difícil \n Escolha: ");
            int nivel = int.Parse(Console.ReadLine());

            while (nivel > 3)
            {
                Console.WriteLine();
                Console.WriteLine("Escolha um dos três niveis apresentados");
                nivel = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

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

            Console.WriteLine($"Tentativas 1 de {tentativas}.");
            Console.WriteLine("------------------------------------");
            Console.Write($"Qual o seu {qtdeChute}o chute? ");
            int chute = int.Parse(Console.ReadLine());

            Console.WriteLine();

            while (chute != numero && tentativas > 0 || chute == numero && tentativas > 0)
            {
                int pontos = (chute - numero) / 2;

                if (pontos < 0)
                {
                    pontos = pontos * -1;
                }

                pontuacao -= pontos;

                if (chute > numero)
                {
                    Console.WriteLine("O seu chute foi menor que o número secreto!");                    
                    Console.WriteLine($"Você fez: {pontuacao} pontos");
                    Console.WriteLine();
                }
                else if (chute < numero)
                {
                    Console.WriteLine("O seu chute foi maior que o número secreto!");                   
                    Console.WriteLine($"Você fez: {pontuacao} pontos");
                    Console.WriteLine();
                }
                else if(chute == numero)
                {
                    tentativas--;
                    Console.WriteLine("Parabéns, você acertou!");                    
                    break;
                }

                qtdeChute++;
                tentativas--;

                Console.WriteLine();
                Console.WriteLine($"Tentativas 1 de {tentativas}.");
                Console.WriteLine("------------------------------------");         
                Console.Write($"Qual o seu {qtdeChute}o Chute? ");
                chute = int.Parse(Console.ReadLine());
            }
        }
    }
}
