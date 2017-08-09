using System.Collections.Generic;
using System.IO;
using System.Reflection;
using VersFx.Formats.Text.Epub;
using Xamarin.Forms;

namespace epubreader
{
	public partial class epubreaderPage : ContentPage
	{
		public epubreaderPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			var assembly = typeof(epubreaderPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("epubreader.Resources.conde.epub");
			EpubBook epubBook = EpubReader.ReadBook(stream);
			this.titleTxt.Text = epubBook.Title;
            this.authorTxt.Text = epubBook.Author;

			var chaptersList = "";
			foreach (EpubChapter chapter in epubBook.Chapters)
			{
				// Title of chapter
				chaptersList += chapter.Title + " ";
			}

			this.chapterList.Text = chaptersList;


		}
	}
}
