using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace Test2.Scripts.ChunkSystem
{
   
    public class ChunkController : MonoBehaviour
    {
        [SerializeField] private List<ChunkView> _chunks;
        [SerializeField] private Vector3 _chankSize;
        [SerializeField] private Vector3 _offset;

        private ChunkView[,] _chunksMatrix;
        private List<ChunkView> _container = new List<ChunkView>();
        private void Awake()
        {
            foreach (var chunk in _chunks)
            {
                chunk.OnEnter += OnEnter;
                chunk.OnExit += OnExit;
            }

            Initialize();
        }
        
        private void Initialize()
        {
            _chunksMatrix = new ChunkView[3, 3];
            int index = 0;
            for (int i = 0; i < _chunksMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _chunksMatrix.GetLength(1); j++)
                {
                    _chunksMatrix[i, j] = _chunks[index];
                    index++;
                }
            }
            UpdatePosition();
        }
        
        private void RemoveCol(out ChunkView[] chunkRemoved, ChunkView [,] matrix, int col)
        {
            chunkRemoved = new ChunkView[3];
            for (int i = 0; i < 3; i++)
            {
                chunkRemoved[i] = matrix[col, i];
            }
        }
        
        private void RemoveRow(out ChunkView[] chunkRemoved, ChunkView [,] matrix, int row)
        {
            chunkRemoved = new ChunkView[3];
            for (int i = 0; i < 3; i++)
            {
                chunkRemoved[i] = matrix[i, row];
            }
        }

        private void ShiftLeft(out ChunkView[,] chunks, ChunkView[,] matrix)
        {
            chunks = new ChunkView[3, 3];
            for (int i = 1; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    chunks[i - 1, j] = matrix[i, j];
                }
            }
        }
        
        private void ShiftRight(out ChunkView[,] chunks, ChunkView[,] matrix)
        {
            chunks = new ChunkView[3, 3];
            for (int i = 2; i > 0; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    chunks[i, j] = matrix[i - 1, j];
                }
            }
        }
        
        private void ShiftDown(out ChunkView[,] chunks, ChunkView[,] matrix)
        {
            chunks = new ChunkView[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    chunks[i, j-1] = matrix[i, j];
                }
            }
        }
        
        private void ShiftUp(out ChunkView[,] chunks, ChunkView[,] matrix)
        {
            chunks = new ChunkView[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 2; j > 0; j--)
                {
                    chunks[i, j] = matrix[i, j - 1];
                }
            }
        }
        
    
        private ChunkView[,] InsertRow(ChunkView[,] chunks, ChunkView[] removedRow, int col)
        {
            for (int i = 0; i < 3; i++)
            {
                chunks[col, i] = removedRow[i];
            }
            return chunks;
        }
        
        private ChunkView[,] InsertCol(ChunkView[,] chunks, ChunkView[] removedRow, int col)
        {
            for (int i = 0; i < 3; i++)
            {
                chunks[i, col] = removedRow[i];
            }
            return chunks;
        }
        
        [Button()]
        private void MoveToLeft()
        {
            var removeIndex = 0;
            var insertIndex = 2;
            
            RemoveCol(out ChunkView[] chunkRemoved, _chunksMatrix, removeIndex);
            ShiftLeft(out ChunkView[,] chunks, _chunksMatrix);
            chunks = InsertRow(chunks, chunkRemoved, insertIndex);
            
            
            _chunksMatrix = chunks;
            UpdatePosition();
        }
        
        [Button()]
        private void MoveToRight()
        {
            var removeIndex = 2;
            var insertIndex = 0;
            
            RemoveCol(out ChunkView[] chunkRemoved, _chunksMatrix, removeIndex);
            ShiftRight(out ChunkView[,] chunks, _chunksMatrix);
            chunks = InsertRow(chunks, chunkRemoved, insertIndex);

            _chunksMatrix = chunks;
            UpdatePosition();
        }
        
       
        [Button()]
        private void MoveToTop()
        {
            var removeIndex = 2;
            var insertIndex = 0;
            
            
            RemoveRow(out ChunkView[] chunkRemoved, _chunksMatrix, removeIndex);
            ShiftUp(out ChunkView[,] chunks, _chunksMatrix);
            chunks = InsertCol(chunks, chunkRemoved, insertIndex);

            _chunksMatrix = chunks;
            UpdatePosition();
        }
    
        [Button()]
        private void MoveToDown()
        {
            var removeIndex = 0;
            var insertIndex = 2;
            
            
            RemoveRow(out ChunkView[] chunkRemoved, _chunksMatrix, removeIndex);
            ShiftDown(out ChunkView[,] chunks, _chunksMatrix);
            chunks = InsertCol(chunks, chunkRemoved, insertIndex);

            _chunksMatrix = chunks;
            UpdatePosition();
        }
        

        private void UpdatePosition()
        {
            var currentTrigger = _chunksMatrix[1, 1];
            var currentPosition = currentTrigger.transform.position;

            for (int i = 0; i < _chunksMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _chunksMatrix.GetLength(1); j++)
                {
                    var position = currentPosition;
                    position.x = currentPosition.x - _chankSize.x * (i - 1);
                    position.z = currentPosition.z - _chankSize.z * (j - 1);
                    _chunksMatrix[i, j].transform.position = position;
                }
            }
        }

        
        
        private void OnEnter(ChunkView trigger)
        {
            if (_container.Contains(trigger) == false)
            {
                _container.Add(trigger);
            }
            OnChangeTriggers();
        }

        private void OnExit(ChunkView trigger)
        {
            if (_container.Contains(trigger))
            {
                _container.Remove(trigger);
            }
            OnChangeTriggers();
        }

        private (int, int) GetIndexOf(ChunkView [,] matrix, ChunkView chunkView)
        {
            (int, int) index = (1, 1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == chunkView)
                    {
                        index.Item1 = i;
                        index.Item2 = j;
                        return index;
                    }
                }
            }

            return index;
        }
        private void OnChangeTriggers()
        {
            if (_container.Count > 0)
            {
                var currentChunk = _container.Last();
                
                var index = GetIndexOf(_chunksMatrix, currentChunk);
                var indexI = index.Item1;
                var indexJ = index.Item2;

                if (indexI == 0)
                {
                    MoveToRight();
                }
                else if (indexI == 2)
                {
                    MoveToLeft();
                }

                if (indexJ == 0)
                {
                    MoveToTop();
                }
                else if (indexJ == 2)
                {
                    MoveToDown();
                }

            }
        }
    
    
        [Button()]
        private void Init()
        {
            var currentPosition = transform.position;
            currentPosition += _offset;


            for (int i = 0; i < _chunks.Count; i++)
            {
                var indexLine = GetIndexLine(i);
                var indexCol = GetIndexCol(i);

                var position = currentPosition;
                position.x = currentPosition.x - _chankSize.x * (indexLine - 1);
                position.z = currentPosition.z - _chankSize.z * (indexCol - 1);
                _chunks[i].transform.position = position;
            }
        }

        private int GetIndexLine(int index)
        {
            return index / 3;
        }

        private int GetIndexCol(int index)
        {
            return index % 3;
        }
    }
}