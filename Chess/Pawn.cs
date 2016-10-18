using System;

namespace Gfi.Hiring
{
    public delegate void OnMoveEventHandler(Pawn sender, int newX, int newY, MovementType movementType);

    public class Pawn
    {
        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;

        public event OnMoveEventHandler OnMove;
        
        public ChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
            //1. Check if move is a legal move
            // - Can move left or right 1 space
            // - Can move forward 1 space but not back
            if (Math.Abs(newX - XCoordinate) <= 1  && (newY > YCoordinate && newY == YCoordinate + 1))
            {
                //2. Raise  an OnMove event so that chessboard can move the peice to its new location.
                if (OnMove != null)
                {
                    OnMove(this, newX, newY, movementType);
                }
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
