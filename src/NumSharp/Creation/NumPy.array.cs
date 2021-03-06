﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
 
namespace NumSharp
{
	public static partial class NumPyExtensions
	{
        public static NDArray<T> array<T>(this NumPy<T> np, IEnumerable<T> array, int ndim = 1)
        {
			var nd = new NDArray<T>();
			nd.Data = array.ToArray();
            nd.Shape = new Shape(new int[] { nd.Data.Length });

            return nd;
        }
        
        public static NDArray<Byte> array(System.Drawing.Bitmap image )
        {
            NDArray<Byte> imageArray = new NDArray<byte>();

            var bmpd = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, image.PixelFormat);
            var dataSize = bmpd.Stride * bmpd.Height;

            imageArray.Data = new byte[dataSize];
            System.Runtime.InteropServices.Marshal.Copy(bmpd.Scan0, imageArray.Data, 0, imageArray.Data.Length);
            image.UnlockBits(bmpd);

            imageArray.Shape = new Shape(new int[] { bmpd.Height, bmpd.Width, 3 });
    
            return imageArray;  
        }

		public static NDArray<T> array<T>(T[][] data)
		{
			int size = data.Length * data[0].Length;
			var all = new T[size];

			int idx = 0;
			for (int row = 0; row < data.Length; row++)
			{
				for (int col = 0; col < data[row].Length; col++)
				{
					all[idx] = data[row][col];
					idx++;
				}
			}

			var n = new NDArray<T>();
			n.Data = all;
			n.Shape = new Shape(new int[] { data.Length, data[0].Length });

			return n;
		}

	}
}
