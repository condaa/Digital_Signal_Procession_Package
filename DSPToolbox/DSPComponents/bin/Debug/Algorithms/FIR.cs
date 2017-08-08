using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class FIR : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public FILTER_TYPES InputFilterType { get; set; }
        public float InputFS { get; set; }
        public float? InputCutOffFrequency { get; set; }
        public float? InputF1 { get; set; }
        public float? InputF2 { get; set; }
        public float InputStopBandAttenuation { get; set; }
        public float InputTransitionBand { get; set; }
        public Signal OutputHn { get; set; }
        public Signal OutputYn { get; set; }

        public override void Run()
        {
            #region initializations
            OutputHn = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            OutputYn = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            double delta_f = InputTransitionBand, Fc_dash = 0, f1_dash = 0, f2_dash = 0, omega_c = 0, omega_c1 = 0, omega_c2 = 0;
            #endregion

            #region get f', omega and N
            get_f_dash_and_omega(InputFilterType, delta_f, ref Fc_dash, ref f1_dash, ref f2_dash, ref omega_c, ref omega_c1, ref omega_c2);
            int N = get_N(InputStopBandAttenuation, delta_f, InputFS); // FIR coefficients
            #endregion

            #region get OutputHn
            double hd;
            double wc;
            Signal output_hn = new Signal(new List<float>(), false, new List<float>(), new List<float>(), new List<float>());
            output_hn.Samples = Enumerable.Repeat(default(float), N).ToList();
            output_hn.SamplesIndices = Enumerable.Repeat(default(int), N).ToList();

            #region Low Case
            if (InputFilterType == FILTER_TYPES.LOW)
            {

                for (int n = 0; n <= N / 2; n++)
                {
                    if (n == 0)
                        hd = 2 * Fc_dash;
                    else
                        hd = 2 * Fc_dash * (Math.Sin(n * omega_c) / (n * omega_c));

                    if (InputStopBandAttenuation <= 21)
                        wc = 1;
                    else if (InputStopBandAttenuation <= 44)
                        wc = .5 + .5 * (Math.Cos(2 * Math.PI * n / N));
                    else if (InputStopBandAttenuation <= 53)
                        wc = .54 + .46 * (Math.Cos(2 * Math.PI * n / N));
                    else
                        wc = .42 + .5 * (Math.Cos(2 * Math.PI * n / (N - 1))) + .08 * (Math.Cos(4 * Math.PI * n / (N - 1)));

                    output_hn.Samples[N / 2 - n] = (float)(hd * wc);
                    output_hn.Samples[N / 2 + n] = (float)(hd * wc);

                    output_hn.SamplesIndices[N / 2 - n] = -n;
                    output_hn.SamplesIndices[N / 2 + n] = n;
                }

            }
            #endregion
            #region High Case
            else if (InputFilterType == FILTER_TYPES.HIGH)
            {

                for (int n = 0; n <= N / 2; n++)
                {
                    if (n == 0)
                        hd = 1 - 2 * Fc_dash;
                    else
                        hd = -2 * Fc_dash * (Math.Sin(n * omega_c) / (n * omega_c));

                    if (InputStopBandAttenuation <= 21)
                        wc = 1;
                    else if (InputStopBandAttenuation <= 44)
                        wc = .5 + .5 * (Math.Cos(2 * Math.PI * n / N));
                    else if (InputStopBandAttenuation <= 53)
                        wc = .54 + .46 * (Math.Cos(2 * Math.PI * n / N));
                    else
                        wc = .42 + .5 * (Math.Cos(2 * Math.PI * n / (N - 1))) + .08 * (Math.Cos(4 * Math.PI * n / (N - 1)));

                    output_hn.Samples[N / 2 - n] = (float)(hd * wc);
                    output_hn.Samples[N / 2 + n] = (float)(hd * wc);

                    output_hn.SamplesIndices[N / 2 - n] = -n;
                    output_hn.SamplesIndices[N / 2 + n] = n;
                }

            }
            #endregion
            #region BAND_PASS Case
            else if (InputFilterType == FILTER_TYPES.BAND_PASS)
            {
                for (int n = 0; n <= N / 2; n++)
                {
                    if (n == 0)
                        hd = 2 * (f2_dash - f1_dash);
                    else
                        hd = 2 * f2_dash * (Math.Sin(n * omega_c2) / (n * omega_c2)) - 2 * f1_dash * (Math.Sin(n * omega_c1) / (n * omega_c1));

                    if (InputStopBandAttenuation <= 21)
                        wc = 1;
                    else if (InputStopBandAttenuation <= 44)
                        wc = .5 + .5 * (Math.Cos(2 * Math.PI * n / N));
                    else if (InputStopBandAttenuation <= 53)
                        wc = .54 + .46 * (Math.Cos(2 * Math.PI * n / N));
                    else
                        wc = .42 + .5 * (Math.Cos(2 * Math.PI * n / (N - 1))) + .08 * (Math.Cos(4 * Math.PI * n / (N - 1)));

                    output_hn.Samples[N / 2 - n] = (float)(hd * wc);
                    output_hn.Samples[N / 2 + n] = (float)(hd * wc);

                    output_hn.SamplesIndices[N / 2 - n] = -n;
                    output_hn.SamplesIndices[N / 2 + n] = n;
                }

            }
            #endregion
            #region BAND_Stop Case
            else
            {
                for (int n = 0; n <= N / 2; n++)
                {
                    if (n == 0)
                        hd = 1 - 2 * (f2_dash - f1_dash);
                    else
                        hd = 2 * f1_dash * (Math.Sin(n * omega_c1) / (n * omega_c1)) - 2 * f2_dash * (Math.Sin(n * omega_c2) / (n * omega_c2));

                    if (InputStopBandAttenuation <= 21)
                        wc = 1;
                    else if (InputStopBandAttenuation <= 44)
                        wc = .5 + .5 * (Math.Cos(2 * Math.PI * n / N));
                    else if (InputStopBandAttenuation <= 53)
                        wc = .54 + .46 * (Math.Cos(2 * Math.PI * n / N));
                    else
                        wc = .42 + .5 * (Math.Cos(2 * Math.PI * n / (N - 1))) + .08 * (Math.Cos(4 * Math.PI * n / (N - 1)));

                    output_hn.Samples[N / 2 - n] = (float)(hd * wc);
                    output_hn.Samples[N / 2 + n] = (float)(hd * wc);

                    output_hn.SamplesIndices[N / 2 - n] = -n;
                    output_hn.SamplesIndices[N / 2 + n] = n;
                }

            }
            #endregion

            OutputHn = new Signal(new List<float>(output_hn.Samples), new List<int>(output_hn.SamplesIndices), false);
            #endregion

            #region et OutputYn
            DirectConvolution convolution = new DirectConvolution();
            convolution.InputSignal1 = InputTimeDomainSignal;
            convolution.InputSignal2 = output_hn;
            convolution.Run();

            OutputYn = convolution.OutputConvolvedSignal;
            #endregion

        }

        void get_f_dash_and_omega(FILTER_TYPES InputFilterType, double delta_f, ref double Fc_dash, ref double f1_dash, ref double f2_dash, ref double omega_c, ref double omega_c1, ref double omega_c2)
        {
            double Fc = 0;
            if (InputFilterType == FILTER_TYPES.LOW || InputFilterType == FILTER_TYPES.HIGH)
                Fc = (double)InputCutOffFrequency;

            if (InputFilterType == FILTER_TYPES.LOW)
            {
                Fc_dash = Fc + (delta_f / 2);
                Fc_dash /= InputFS; // normalization
                omega_c = 2 * Math.PI * Fc_dash;
            }
            else if (InputFilterType == FILTER_TYPES.HIGH)
            {
                Fc_dash = Fc - (delta_f / 2);
                Fc_dash /= InputFS; // normalization
                omega_c = 2 * Math.PI * Fc_dash;
            }
            else if (InputFilterType == FILTER_TYPES.BAND_PASS)
            {
                f1_dash = (double)InputF1 - (0.5 * delta_f);
                f2_dash = (double)InputF2 + (0.5 * delta_f);
                f1_dash /= InputFS; // normalization
                f2_dash /= InputFS; // normalization

                omega_c1 = 2 * Math.PI * f1_dash;
                omega_c2 = 2 * Math.PI * f2_dash;
            }
            else
            {
                f1_dash = (double)InputF1 + (0.5 * delta_f);
                f2_dash = (double)InputF2 - (0.5 * delta_f);
                f1_dash /= InputFS; // normalization
                f2_dash /= InputFS; // normalization

                omega_c1 = 2 * Math.PI * f1_dash;
                omega_c2 = 2 * Math.PI * f2_dash;
            }

        }
        int get_N(float InputStopBandAttenuation, double delta_f, float InputFS)
        {
            double transition_width;

            if (InputStopBandAttenuation <= 21)
                transition_width = 0.9;                     // over N
            else if (InputStopBandAttenuation <= 44)
                transition_width = 3.1;
            else if (InputStopBandAttenuation <= 53)
                transition_width = 3.3;
            else
                transition_width = 5.5;

            int N = (int)Math.Round(transition_width / (delta_f / InputFS)); // bn3ml normaliztion lel delta f we e7na bngeb N
            if (N % 2 == 0) N++;

            return N;
        }

    }
}
