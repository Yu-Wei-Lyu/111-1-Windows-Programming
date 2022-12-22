﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StatePointer : StateClickHandler
    {
        // Pressed 
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null)
                return null;
            Shape newShape = this._shapeFactory.CreateSelectBox(referenceShape);
            return newShape;
        }
        // Released
        public override Shape Released(Shapes shapes, Shape movedShape, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null)
                return null;
            Shape newShape = this._shapeFactory.CreateSelectBox(referenceShape);
            return newShape;
        }
    }
}