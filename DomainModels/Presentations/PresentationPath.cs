using DomainModels.Slides;

namespace DomainModels.Presentations
{
    public static class PresentationPath
    {
        public static class SlidePath
        {
            public static string Path = $"{nameof(Presentation.Slides)}";

            public static class SlideOptionPath
            {
                public static string Path = $"{nameof(Presentation.Slides)}.{nameof(Slide.SlideOptions)}";
            }
        }
    }
}
