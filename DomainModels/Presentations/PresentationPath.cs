using DomainModels.Slides;

namespace DomainModels.Presentations
{
    public static class PresentationPath
    {
        public static string Path = nameof(Presentation);

        public static class SlidePath
        {
            public static string Path = $"{nameof(Presentation)}s.{nameof(Slide)}s";

            public static class SlideOptionPath
            {
                public static string Path = $"{nameof(Presentation)}s.{nameof(Slide)}s.{nameof(SlideOption)}s";
            }
        }
    }
}
