using System;
using WebKit.Interop;


namespace WebKit
{
    internal class WebDownloadDelegate : IWebDownloadDelegate
    {
        public void decideDestinationWithSuggestedFilename(WebDownload download, string fileName)
        {}

        public void didBegin(WebDownload download)
        {}

        public void didCancelAuthenticationChallenge(WebDownload download, IWebURLAuthenticationChallenge challenge)
        {}

        public void didCreateDestination(WebDownload download, string destination)
        {}

        public void didFailWithError(WebDownload download, WebError error)
        {}

        public void didFinish(WebDownload download)
        {}

        public void didReceiveAuthenticationChallenge(WebDownload download, IWebURLAuthenticationChallenge challenge)
        {}

        public void didReceiveDataOfLength(WebDownload download, uint length)
        {}

        public void didReceiveResponse(WebDownload download, WebURLResponse response)
        {}

        public int shouldDecodeSourceDataOfMIMEType(WebDownload download, string encodingType)
        {
            throw new NotImplementedException();
        }

        public void willResumeWithResponse(WebDownload download, WebURLResponse response, long fromByte)
        {}

        public void willSendRequest(WebDownload download, WebMutableURLRequest request, WebURLResponse redirectResponse, out WebMutableURLRequest finalRequest)
        {
            throw new NotImplementedException();
        }
    }
}
