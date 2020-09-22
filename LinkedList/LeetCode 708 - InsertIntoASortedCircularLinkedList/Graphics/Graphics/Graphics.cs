using Graphics.Strategy;

namespace Graphics
{
    public class Graphics
    {
        private IStrokeStrategy _strokeStrategy;
        private IFillStrategy _fillStrategy;

        public Graphics(IStrokeStrategy strokeStrategy, IFillStrategy fillStrategy)
        {
            _strokeStrategy = strokeStrategy;
            _fillStrategy = fillStrategy;
        }

        public void SetStrokeStrategy(IStrokeStrategy strokeStrategy)
        {
            _strokeStrategy = strokeStrategy;
        }

        public void SetFillStrategy(IFillStrategy fillStrategy)
        {
            _fillStrategy = fillStrategy;
        }

        public void Stroke()
        {
            _strokeStrategy.Stroke();
        }

        public void Fill()
        {
            _fillStrategy.Fill();
        }
    }
}