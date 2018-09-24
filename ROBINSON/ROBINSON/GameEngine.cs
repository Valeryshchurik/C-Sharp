using System.Linq;

namespace ISO_Robinson.Game
{
    public class GameEngine
    {
        private readonly PlayerA _playerA;
        private readonly PlayerB _playerB;
        private readonly uint _countOfParties;
        private readonly string[] _gameHistory;
        private int N { get; }
        private int M { get; }
        public double UpperBound { get; private set; }
        public double LowerBound { get; private set; }
        public int[] StrategyA => _playerA.StrategicSet;
        public int[] StrategyB => _playerB.StrategicSet;
        public uint CountOfParties => _countOfParties;
        public string[] GameHistory => _gameHistory;
        private readonly int [,] _matrix;

        public GameEngine(uint countOfParties, int[,] matrix)
        {
            _countOfParties = countOfParties;
            _matrix = matrix;
            N = matrix.GetLength(0);
            M = matrix.GetLength(1);
            _playerA = new PlayerA(N);
            _playerB = new PlayerB(M);
            _gameHistory = new string[2 * countOfParties];
            Play();
        }

        private void PlayParty(uint j)
        {
            CalculateA(j);
            CalculateB(j);
            _playerA.ChangeStrategy();
            _playerB.ChangeStrategy();
        }

        private void Play()
        {
            _playerA.SupposedStrategy = 1;
            _playerB.SupposedStrategy = 1;
            for (uint counter = CountOfParties; counter > 0; counter--)
            {
                PlayParty(CountOfParties - counter);
            }
            UpperBound = (double)_playerA.ResultSet.Max() / CountOfParties;
            LowerBound = (double)_playerB.ResultSet.Min() / CountOfParties;
        }

        private void CalculateA(uint j)
        {
            for (int i = 0; i < N; i++)
            {
                _playerA.ResultSet[i] += _matrix[i, _playerB.SupposedStrategy - 1];
            }
            _playerB.StrategicSet[_playerB.SupposedStrategy - 1]++;
            GameHistory[2 * j] = (j + 1) + " A " + "s" + _playerA.SupposedStrategy + " " + string.Join(" ", _playerA.ResultSet);
        }

        private void CalculateB(uint j)
        {
            for (int i = 0; i < M; i++)
            {
                _playerB.ResultSet[i] += _matrix[_playerA.SupposedStrategy - 1, i];
            }
            _playerA.StrategicSet[_playerA.SupposedStrategy - 1]++;
            GameHistory[2 * j + 1] = (j + 1) + " B " + "s" + _playerB.SupposedStrategy + " " + string.Join(" ", _playerB.ResultSet);
        }
    }
}
