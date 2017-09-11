using NotificationsExtensions.TileContent;
using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace CamadoWin8.Services.Infrastructure
{
    public class TileService : ITileService
    {
        public void SendSimpleTextUpdate(string text)
        {
            ITileWideText03 tileContent = 
                TileContentFactory.CreateTileWideText03();
            tileContent.TextHeadingWrap.Text = text;

            ITileSquareText04 squareContent = 
                TileContentFactory.CreateTileSquareText04();
            squareContent.TextBodyWrap.Text = text;
            tileContent.SquareContent = squareContent;

            // send the notification
            TileUpdateManager.CreateTileUpdaterForApplication()
                .Update(tileContent.CreateNotification());
        }

        public void SendImageAndTextUpdate(string text, string imageUrl)
        {
            ITileWideImageAndText01 tileContent = TileContentFactory.CreateTileWideImageAndText01();

            tileContent.TextCaptionWrap.Text = text;
            tileContent.Image.Src = "http://localhost:35756/images/sanfrancisco.jpg";
            tileContent.Image.Alt = "Recommended trip";

            ITileSquareImage squareContent = TileContentFactory.CreateTileSquareImage();
            squareContent.Image.Src = "http://localhost:35756/images/sanfrancisco.jpg";
            squareContent.Image.Alt = "Recommended trip";
            tileContent.SquareContent = squareContent;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

    }
}
