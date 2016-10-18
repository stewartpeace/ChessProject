using System;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Pawn[,] pieces;

        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) && pieces.GetValue(xCoordinate, yCoordinate) == null)
            {
                pawn.XCoordinate = xCoordinate;
                pawn.YCoordinate = yCoordinate;
                pieces[xCoordinate, yCoordinate] = pawn;
            }
            else
            {
                pawn.XCoordinate = -1;
                pawn.YCoordinate = -1;
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate >= 0 && MaxBoardWidth > xCoordinate ) && ( yCoordinate >= 0 &&  MaxBoardHeight > yCoordinate)  ? true : false;
        }

    }
}
