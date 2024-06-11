using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiPhotoCaptureDemo
{
	public partial class MainPageViewModel : ObservableObject
	{
		[ObservableProperty]
		public ImageSource? photoImageSource;

		public MainPageViewModel()
		{
		}

		[RelayCommand]
		public async Task TakePhoto()
		{
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    PhotoImageSource = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show a message to the user)
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task PickPhoto()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    PhotoImageSource = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show a message to the user)
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
	}
}

