using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns,
    }
    public FitType fitType;

    public int rows;
    public int columns;

    public Vector2 cellSize;
    public Vector2 spacing;

    public bool fitX;
    public bool fitY;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform) 
        {
            float sqrt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrt);
            columns = Mathf.CeilToInt(sqrt);
        }

        if(fitType == FitType.Width || fitType == FitType.FixedColumns)
        {
            rows = Mathf.CeilToInt(transform.childCount / (float)columns);
        }        

        if(fitType == FitType.Height || fitType == FitType.FixedRows)
        {
            columns = Mathf.CeilToInt(transform.childCount / (float)rows);
        }

        float parentWidth = rectTransform.rect.width ;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns ) * 2) - (padding.left / (float) columns) - (padding.right / (float)columns);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows); ;

        cellSize.x = fitX ? cellWidth : cellSize.x ;
        cellSize.y = fitY ? cellHeight : cellSize.x;

        int columnCount = 0;
        int rowCount = 0;


        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPosition = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
            var yPosition = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPosition, cellSize.x);
            SetChildAlongAxis(item, 1, yPosition, cellSize.y);

        }

        //Debug.Log(columnCount * (cellSize.x + spacing.x);

        if(columnCount * (cellSize.x + spacing.x) > parentWidth)
        {
            Debug.Log("DLINNEEEEE");
        }
        //float scaleX = ;
    }
    public override void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }
}
