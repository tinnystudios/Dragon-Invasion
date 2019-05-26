public interface IGrabbable
{
    IGrabber Grabber { get; }
    bool CanGrab { get; }
    bool CanDetatch { get; }

    void AttachTo(IGrabber grabber);
    void Detatch(IGrabber grabber);
}