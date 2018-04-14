using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Todo.Common
{
    public class LiveTileService
    {
        public LiveTileService()
        {
        }

        //添加动态磁贴，title为磁贴的标题，detail为磁贴的内容，source为背景图片
        public void AddTile(string title, string detail, string source)
        {
            //得到磁贴的对象
            TileContent content = CreateTileContent(title, detail, source);
            var notification = new TileNotification(content.GetXml());
            //添加到磁贴的队列
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        private TileContent CreateTileContent(string title, string detail, string source)
        {
            //获得
            return new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                //设置标题
                                new AdaptiveText()
                                {
                                    Text = title,
                                    HintStyle = AdaptiveTextStyle.Title
                                },
                                //设置内容
                                new AdaptiveText()
                                {
                                    Text = detail,
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                }
                            },
                            //设置背景图片
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = source
                            }
                        }
                    },
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = title,
                                    HintStyle = AdaptiveTextStyle.Title
                                },
                                new AdaptiveText()
                                {
                                    Text = detail,
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                }
                            },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = source
                            }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = title,
                                    HintStyle = AdaptiveTextStyle.Title
                                },
                                new AdaptiveText()
                                {
                                    Text = detail,
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                }
                            },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = source
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = title,
                                    HintStyle = AdaptiveTextStyle.Title
                                },
                                new AdaptiveText()
                                {
                                    Text = detail,
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                }
                            },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = source
                            }
                        }
                    }
                }
            };
        }

    }
}