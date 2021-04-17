﻿using System;
using System.Windows;
using System.Windows.Media;
using HandyControl.Data;

namespace HandyControl.Tools
{
    public class HatchBrushGenerator
    {
        private static readonly byte[][] HatchBrushes =
        {
            new byte[] {0x00, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00}, // Horizontal
            new byte[] {0x08, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08}, // Vertical
            new byte[] {0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80}, // ForwardDiagonal
            new byte[] {0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01}, // BackwardDiagonal
            new byte[] {0x08, 0x08, 0x08, 0xff, 0x08, 0x08, 0x08, 0x08}, // Cross
            new byte[] {0x81, 0x42, 0x24, 0x18, 0x18, 0x24, 0x42, 0x81}, // DiagonalCross
            new byte[] {0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x80}, // Percent05
            new byte[] {0x00, 0x02, 0x00, 0x88, 0x00, 0x20, 0x00, 0x88}, // Percent10
            new byte[] {0x00, 0x22, 0x00, 0xcc, 0x00, 0x22, 0x00, 0xcc}, // Percent20
            new byte[] {0x00, 0xcc, 0x00, 0xcc, 0x00, 0xcc, 0x00, 0xcc}, // Percent25
            new byte[] {0x00, 0xcc, 0x04, 0xcc, 0x00, 0xcc, 0x40, 0xcc}, // Percent30
            new byte[] {0x44, 0xcc, 0x22, 0xcc, 0x44, 0xcc, 0x22, 0xcc}, // Percent40
            new byte[] {0x55, 0xcc, 0x55, 0xcc, 0x55, 0xcc, 0x55, 0xcc}, // Percent50
            new byte[] {0x55, 0xcd, 0x55, 0xee, 0x55, 0xdc, 0x55, 0xee}, // Percent60
            new byte[] {0x55, 0xdd, 0x55, 0xff, 0x55, 0xdd, 0x55, 0xff}, // Percent70
            new byte[] {0x55, 0xff, 0x55, 0xff, 0x55, 0xff, 0x55, 0xff}, // Percent75
            new byte[] {0x55, 0xff, 0x59, 0xff, 0x55, 0xff, 0x99, 0xff}, // Percent80
            new byte[] {0x77, 0xff, 0xdd, 0xff, 0x77, 0xff, 0xfd, 0xff}, // Percent90
            new byte[] {0x11, 0x22, 0x44, 0x88, 0x11, 0x22, 0x44, 0x88}, // LightDownwardDiagonal
            new byte[] {0x88, 0x44, 0x22, 0x11, 0x88, 0x44, 0x22, 0x11}, // LightUpwardDiagonal
            new byte[] {0x99, 0x33, 0x66, 0xcc, 0x99, 0x33, 0x66, 0xcc}, // DarkDownwardDiagonal
            new byte[] {0xcc, 0x66, 0x33, 0x99, 0xcc, 0x66, 0x33, 0x99}, // DarkUpwardDiagonal
            new byte[] {0xc1, 0x83, 0x07, 0x0e, 0x1c, 0x38, 0x70, 0xe0}, // WideDownwardDiagonal
            new byte[] {0xe0, 0x70, 0x38, 0x1c, 0x0e, 0x07, 0x83, 0xc1}, // WideUpwardDiagonal
            new byte[] {0x88, 0x88, 0x88, 0x88, 0x88, 0x88, 0x88, 0x88}, // LightVertical
            new byte[] {0x00, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00, 0xff}, // LightHorizontal
            new byte[] {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa}, // NarrowVertical
            new byte[] {0x00, 0xff, 0x00, 0xff, 0x00, 0xff, 0x00, 0xff}, // NarrowHorizontal
            new byte[] {0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc}, // DarkVertical
            new byte[] {0x00, 0x00, 0xff, 0xff, 0x00, 0x00, 0xff, 0xff}, // DarkHorizontal
            new byte[] {0x11, 0x22, 0x44, 0x88, 0x00, 0x00, 0x00, 0x00}, // DashedDownwardDiagonal
            new byte[] {0x88, 0x44, 0x22, 0x11, 0x00, 0x00, 0x00, 0x00}, // DashedUpwardDiagonal
            new byte[] {0x0f, 0x00, 0x00, 0x00, 0xf0, 0x00, 0x00, 0x00}, // DashedHorizontal
            new byte[] {0x01, 0x01, 0x01, 0x01, 0x10, 0x10, 0x10, 0x10}, // DashedVertical
            new byte[] {0x01, 0x08, 0x80, 0x10, 0x02, 0x40, 0x04, 0x20}, // SmallConfetti
            new byte[] {0x03, 0x63, 0x6c, 0x0c, 0xc0, 0xc6, 0x36, 0x30}, // LargeConfetti
            new byte[] {0x03, 0x84, 0x48, 0x30, 0x03, 0x84, 0x48, 0x30}, // ZigZag
            new byte[] {0x30, 0x49, 0x06, 0x00, 0x30, 0x49, 0x06, 0x00}, // Wave
            new byte[] {0x81, 0x42, 0x24, 0x18, 0x08, 0x04, 0x02, 0x01}, // DiagonalBrick
            new byte[] {0xff, 0x01, 0x01, 0x01, 0xff, 0x10, 0x10, 0x10}, // HorizontalBrick
            new byte[] {0x11, 0x82, 0x44, 0xa8, 0x11, 0xa2, 0x44, 0x2a}, // Weave
            new byte[] {0x55, 0xaa, 0x55, 0xaa, 0x0f, 0x0f, 0x0f, 0x0f}, // Plaid
            new byte[] {0x02, 0x01, 0x02, 0x00, 0x10, 0x20, 0x10, 0x00}, // Divot
            new byte[] {0x55, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00}, // DottedGrid
            new byte[] {0x11, 0x00, 0x04, 0x00, 0x11, 0x00, 0x40, 0x00}, // DottedDiamond
            new byte[] {0x03, 0x0c, 0x10, 0x20, 0x20, 0x30, 0x48, 0x84}, // Shingle
            new byte[] {0xff, 0x33, 0xff, 0xcc, 0xff, 0x33, 0xff, 0xcc}, // Trellis
            new byte[] {0xee, 0x19, 0x1f, 0x1f, 0xee, 0x91, 0xf1, 0xf1}, // Sphere
            new byte[] {0xff, 0x11, 0x11, 0x11, 0xff, 0x11, 0x11, 0x11}, // SmallGrid
            new byte[] {0x33, 0x33, 0xcc, 0xcc, 0x33, 0x33, 0xcc, 0xcc}, // SmallCheckerBoard
            new byte[] {0x0f, 0x0f, 0x0f, 0x0f, 0xf0, 0xf0, 0xf0, 0xf0}, // LargeCheckerBoard
            new byte[] {0x01, 0x82, 0x44, 0x28, 0x10, 0x28, 0x44, 0x82}, // OutlinedDiamond
            new byte[] {0x08, 0x1c, 0x3e, 0x7f, 0x3e, 0x1c, 0x08, 0x00} // SolidDiamond
        };

        public Brush GetHatchBrush(HatchStyle hatchStyle, Color foreColor, Color backColor)
        {
            var hatchData = GetHatchData(hatchStyle);

            var foreGeometryGroup = new GeometryGroup();

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    if ((hatchData[y] & (0x80 >> x)) > 0)
                    {
                        foreGeometryGroup.Children.Add(new RectangleGeometry(new Rect(x, y, 1, 1)));
                    }
                }
            }

            var drawingBrush = new DrawingBrush
            {
                Viewport = new Rect(0, 0, 8, 8),
                ViewportUnits = BrushMappingMode.Absolute,
                Stretch = Stretch.None,
                TileMode = TileMode.Tile,
                Drawing = new DrawingGroup
                {
                    Children =
                    {
                        new GeometryDrawing
                        {
                            Brush = new SolidColorBrush(backColor),
                            Geometry = new RectangleGeometry(new Rect(0, 0, 8, 8))
                        },
                        new GeometryDrawing
                        {
                            Brush = new SolidColorBrush(foreColor),
                            Geometry = foreGeometryGroup
                        }
                    }
                }
            };
            RenderOptions.SetCachingHint(drawingBrush, CachingHint.Cache);

            return drawingBrush;
        }

        private byte[] GetHatchData(HatchStyle hatchStyle) =>
            hatchStyle < HatchStyle.Horizontal || hatchStyle > HatchStyle.SolidDiamond
                ? throw new ArgumentOutOfRangeException(nameof(hatchStyle))
                : HatchBrushes[(int) hatchStyle];
    }
}
