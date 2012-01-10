using System;
using WebKit.Interop;


namespace WebKit
{
    internal class WebUIDelegate : IWebUIDelegate
    {
        public void addCustomMenuDrawingData(WebView sender, int hMenu)
        {}

        public int canRedo()
        {
            throw new NotImplementedException();
        }

        public int canRunModal(WebView WebView)
        {
            throw new NotImplementedException();
        }

        public void canTakeFocus(WebView sender, int forward, out int result)
        {
            throw new NotImplementedException();
        }

        public int canUndo()
        {
            throw new NotImplementedException();
        }

        public void cleanUpCustomMenuDrawingData(WebView sender, int hMenu)
        {}

        public void contextMenuItemSelected(WebView sender, IntPtr item, CFDictionaryPropertyBag element)
        {}

        public int contextMenuItemsForElement(WebView sender, CFDictionaryPropertyBag element, int defaultItemsHMenu)
        {
            return 0;
        }

        public WebView createModalDialog(WebView sender, IWebURLRequest request)
        {
            return sender;
        }

        public WebView createWebViewWithRequest(WebView sender, IWebURLRequest request)
        {
            return sender;
        }

        public WebDragDestinationAction dragDestinationActionMaskForDraggingInfo(WebView WebView, IDataObject draggingInfo)
        {
            throw new NotImplementedException();
        }

        public WebDragSourceAction dragSourceActionMaskForPoint(WebView WebView, ref tagPOINT point)
        {
            throw new NotImplementedException();
        }

        public void drawCustomMenuItem(WebView sender, IntPtr drawItem)
        {}

        public void drawFooterInRect(WebView WebView, ref tagRECT rect, int drawingContext, uint pageIndex, uint pageCount)
        {}

        public void drawHeaderInRect(WebView WebView, ref tagRECT rect, int drawingContext)
        {}

        public string ftpDirectoryTemplatePath(WebView WebView)
        {
            return string.Empty;
        }

        public int hasCustomMenuImplementation()
        {
            throw new NotImplementedException();
        }

        public int isMenuBarVisible(WebView WebView)
        {
            throw new NotImplementedException();
        }

        public void makeFirstResponder(WebView sender, int responderHWnd)
        {}

        public void measureCustomMenuItem(WebView sender, IntPtr measureItem)
        {}

        public void mouseDidMoveOverElement(WebView sender, CFDictionaryPropertyBag elementInformation, uint modifierFlags)
        {}

        public void paintCustomScrollCorner(WebView WebView, ref _RemotableHandle hDC, tagRECT rect)
        {}

        public void paintCustomScrollbar(WebView WebView, ref _RemotableHandle hDC, tagRECT rect, WebScrollBarControlSize size, uint state, WebScrollbarControlPart pressedPart, int vertical, float value, float proportion, uint parts)
        {}

        public void printFrame(WebView WebView, IWebFrame frame)
        {}

        public void redo()
        {}

        public void registerUndoWithTarget(IWebUndoTarget target, string actionName, object actionArg)
        {}

        public void removeAllActionsWithTarget(IWebUndoTarget target)
        {}

        public int runBeforeUnloadConfirmPanelWithMessage(WebView sender, string message, IWebFrame initiatedByFrame)
        {
            throw new NotImplementedException();
        }

        public int runDatabaseSizeLimitPrompt(WebView WebView, string displayName, IWebFrame initiatedByFrame)
        {
            throw new NotImplementedException();
        }

        public void runJavaScriptAlertPanelWithMessage(WebView sender, string message)
        {}

        public int runJavaScriptConfirmPanelWithMessage(WebView sender, string message)
        {
            throw new NotImplementedException();
        }

        public string runJavaScriptTextInputPanelWithPrompt(WebView sender, string message, string defaultText)
        {
            throw new NotImplementedException();
        }

        public void runModal(WebView WebView)
        {}

        public void runOpenPanelForFileButtonWithResultListener(WebView sender, IWebOpenPanelResultListener resultListener)
        {}

        public void setActionTitle(string actionTitle)
        {}

        public void setContentRect(WebView sender, ref tagRECT contentRect)
        {}

        public void setFrame(WebView sender, ref tagRECT frame)
        {}

        public void setMenuBarVisible(WebView WebView, int visible)
        {}

        public void setResizable(WebView sender, int resizable)
        {}

        public void setStatusBarVisible(WebView sender, int visible)
        {}

        public void setStatusText(WebView sender, string text)
        {}

        public void setToolbarsVisible(WebView sender, int visible)
        {}

        public void shouldPerformAction(WebView WebView, uint itemCommandID, uint sender)
        {}

        public void takeFocus(WebView sender, int forward)
        {}

        public void trackCustomPopupMenu(WebView sender, int hMenu, ref tagPOINT point)
        {}

        public void undo()
        {}

        public int validateUserInterfaceItem(WebView WebView, uint itemCommandID, int defaultValidation)
        {
            throw new NotImplementedException();
        }

        public int webViewAreToolbarsVisible(WebView sender)
        {
            throw new NotImplementedException();
        }

        public void webViewClose(WebView sender)
        {}

        public tagRECT webViewContentRect(WebView sender)
        {
            throw new NotImplementedException();
        }

        public int webViewFirstResponder(WebView sender)
        {
            throw new NotImplementedException();
        }

        public void webViewFocus(WebView sender)
        {}

        public float webViewFooterHeight(WebView WebView)
        {
            throw new NotImplementedException();
        }

        public tagRECT webViewFrame(WebView sender)
        {
            throw new NotImplementedException();
        }

        public float webViewHeaderHeight(WebView WebView)
        {
            throw new NotImplementedException();
        }

        public int webViewIsResizable(WebView sender)
        {
            throw new NotImplementedException();
        }

        public int webViewIsStatusBarVisible(WebView sender)
        {
            return 0;
        }

        public tagRECT webViewPrintingMarginRect(WebView WebView)
        {
            throw new NotImplementedException();
        }

        public void webViewShow(WebView sender)
        {}

        public string webViewStatusText(WebView sender)
        {
            throw new NotImplementedException();
        }

        public void webViewUnfocus(WebView sender)
        {}

        public void willPerformDragDestinationAction(WebView WebView, WebDragDestinationAction action, IDataObject draggingInfo)
        {}

        public IDataObject willPerformDragSourceAction(WebView WebView, WebDragSourceAction action, ref tagPOINT point, IDataObject pasteboard)
        {
            throw new NotImplementedException();
        }
    }
}
