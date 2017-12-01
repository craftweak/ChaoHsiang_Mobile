//
// Klak - Utilities for creative coding with Unity
//
// Copyright (C) 2016 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using UnityEngine;

namespace Klak.Wiring
{
    [AddComponentMenu("Klak/Wiring/Input/PUTASPECTRUM")]
    public class PUTASPECTRUM : NodeBase
    {
        #region Editable properties
        public AudioSpectrum audioSpectrum;
        #endregion

        #region Node I/O

        [SerializeField, Outlet]
        FloatEvent lowEvent = new FloatEvent();
        [SerializeField, Outlet]
        FloatEvent midLowEvent = new FloatEvent();
        [SerializeField, Outlet]
        FloatEvent midHighEvent = new FloatEvent();
        [SerializeField, Outlet]
        FloatEvent highEvent = new FloatEvent();

        #endregion

        #region MonoBehaviour functions

        void Start()
        {

        }

        void Update() {
            float[] meanLevels = audioSpectrum.MeanLevels;
            lowEvent.Invoke(meanLevels[0]);
            midLowEvent.Invoke(meanLevels[1]);
            midHighEvent.Invoke(meanLevels[2]);
            highEvent.Invoke(meanLevels[3]);

        }

        #endregion
    }
}
