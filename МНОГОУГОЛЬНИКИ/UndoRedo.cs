using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace МНОГОУГОЛЬНИКИ
{
    abstract class UndoRedo // абстрактный класс для всех действий
    {
        public abstract void Undo();
        public abstract void Redo();
    }
    class Add : UndoRedo // класс, отвечающий за добавление вершины
    {
        List<FIGURE> changes = new List<FIGURE>(); // список изменений
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class Remove : UndoRedo // класс, отвечающий за удаление вершины
    {
        List<FIGURE> changes = new List<FIGURE>(); // список изменений
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class Replace : UndoRedo // класс, отвечающий за перемещение фигур
    {
        List<FIGURE> changes = new List<FIGURE>(); // список изменений
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class ColorChange : UndoRedo // класс, отвечающий за изменение цветов
    {
        Color Pref; // предыдущий цвет
        Color New; // новый цвет
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class SizeChange : UndoRedo // класс, отвечающий за изменение размеров
    {
        int Pref; // предыдущий размер
        int New; // новый размер
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class MovingChange : UndoRedo // класс, отвечающий за колебание/динамику фигур
    {
        List<PointF> changes = new List<PointF>(); // список с изменениями положений
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class СhoiceTypeOfFigure : UndoRedo // класс, отвечающий за выбор типа фигуры
    {
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
    class SaveLoad : UndoRedo // класс, отвечающий за выбор файла
    {
        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }
}
