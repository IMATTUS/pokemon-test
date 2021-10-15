using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Treinador
    {
        /* A classe Treinador tem o nome e o calculo da quantidade de pokemons 
         * apanhados pelo treinador
         */ 
        public string Nome { get; set; }
        public int PokemonApanhado { get; set; }

        /* usando dicionario para armazenar a posição como string, usando
             * a casa inicial como 0,0, o Norte e o Sul como eixo Y e o Este e Oeste
             * como eixo X 
             */
        private IDictionary<string, string> Posicao = new Dictionary<string, string>();

        /*
         * Metodo que vai calcular o numero de pokemons apanhados
         */
        private void MovimentaTreinador(string movimento)
        {
            int PosX, PosY;
            PosX = 0;
            PosY = 0;

            movimento = movimento.ToUpper();

            
            // Ash inicia na primeira casa e captura o Pokemon que está ali.
            Posicao.Add("0,0", "1");

            /*
             * percorrando todas as letras inseridas pelo usuário e definindo 
             * se é um movimento válido (N, S, O, E) se não for isso, não toma ação
             */
            foreach (var item in movimento)
            {
                switch (item)
                {
                    case 'N':
                        PosY++;
                        if (Posicao.ContainsKey(PosX.ToString() + ',' + PosY.ToString()) == false)
                        {
                            Posicao.Add(PosX.ToString() + ',' + PosY.ToString(), "1");
                        }
                        break;
                    case 'S':
                        PosY--;
                        if (Posicao.ContainsKey(PosX.ToString() + ',' + PosY.ToString()) == false)
                        {
                            Posicao.Add(PosX.ToString() + ',' + PosY.ToString(), "1");
                        }
                        break;
                    case 'E':
                        PosX++;
                        if (Posicao.ContainsKey(PosX.ToString() + ',' + PosY.ToString()) == false)
                        {
                            Posicao.Add(PosX.ToString() + ',' + PosY.ToString(), "1");
                        }
                        break;
                    case 'O':
                        PosX--;
                        if (Posicao.ContainsKey(PosX.ToString() + ',' + PosY.ToString()) == false)
                        {
                            Posicao.Add(PosX.ToString() + ',' + PosY.ToString(), "1");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public int ApanhaPokemon(string movimento)
        {

            // chamando metodo de movimento do treinador
            MovimentaTreinador(movimento);
            
            /* used for debug
            foreach (var kvp in Posicao)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            */

            // atribuindo numero total de casas visitadas = numero total de pokemons
            PokemonApanhado = Posicao.Count();

            Posicao.Clear();
            return PokemonApanhado;
        }
    }
}
