﻿using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Platform;
using OpenTK.Platform.Tizen;
using Tizen.Applications;

namespace TizenOpenTKApp1
{
    public class OpenTKApp : TizenGameApplication
    {
        private IGameWindow mainWindow;

        private int mProgramHandle;
        private int mColorHandle;
        private int mPositionHandle;

        private float[] mVertexes;          // Vertix of triangle
        private float[] mColor;             // Color of triangle

        private string mVertexShaderSrc;    // Vertex shader
        private string mFragmentShaderSrc;  // Fragment shader

        public OpenTKApp()
        {
            mVertexes = new float[] {
                    0.0f, 0.5f, 0.0f,
                    -0.5f, -0.5f, 0.0f,
                    0.5f, -0.5f, 0.0f
                };

            mColor = new float[] { 0.0f, 0.0f, 1.0f, 1.0f };

            mVertexShaderSrc = "attribute vec4 vPosition;        \n" +
                              "void main()                       \n" +
                              "{                                 \n" +
                              "   gl_Position = vPosition;       \n" +
                              "}                                 \n";
            mFragmentShaderSrc = "precision mediump float;       \n" +
                               "uniform vec4 vColor;             \n" +
                               "void main()                      \n" +
                               "{                                \n" +
                               "  gl_FragColor = vColor;         \n" +
                               "}                                \n";
        }

        protected override void OnCreate()
        {
            // Handle when your app is created
            // At this point, GraphicsContext, Surface, Window had been created

            base.OnCreate();

            mainWindow = Window;

            mainWindow.Load += InitShader;                      // InitApp is called before the window is displayed for the first time
            mainWindow.RenderFrame += RenderTriangle;           // RenderTriangle is called for every frame
        }
        protected override void OnPause()
        {
            // Handle when your app pause
        }
        protected override void OnResume()
        {
            // Handle when your app resume
        }
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            // Handle when your app receive app control event
        }
        protected override void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            // Handle when your app 
        }
        protected override void OnTerminate()
        {
            // Handle when your app terminate
        }

        private void InitShader(object sender, EventArgs e)
        {
            // Create program and link it.
            mProgramHandle = BuildProgram(mVertexShaderSrc, mFragmentShaderSrc);
            GL.LinkProgram(mProgramHandle);

            int linkStatus;
            GL.GetProgram(mProgramHandle, GetProgramParameterName.LinkStatus, out linkStatus);
            if (linkStatus == 0)
            {
                // link failed
                int infoLogLength;
                GL.GetProgram(mProgramHandle, GetProgramParameterName.InfoLogLength, out infoLogLength);
                if (infoLogLength > 0)
                {
                    string infoLog;
                    GL.GetProgramInfoLog(mProgramHandle, infoLogLength, out infoLogLength, out infoLog);
                    Console.WriteLine("GL2", "Couldn't link program: " + infoLog.ToString());
                }
                GL.DeleteProgram(mProgramHandle);

                throw new InvalidOperationException("Unable to link program");
            }
        }
        private void RenderTriangle(object ob, FrameEventArgs e)
        {
            GL.ClearColor(Color4.White);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(mProgramHandle);

            // Set vertex of triangle
            mPositionHandle = GL.GetAttribLocation(mProgramHandle, "vPosition");
            GL.EnableVertexAttribArray(mPositionHandle);
            unsafe
            {
                fixed (float* pvertices = mVertexes)
                {
                    GL.VertexAttribPointer(mPositionHandle, 3, All.Float, false, 0, new IntPtr(pvertices));
                }
            }

            // Set color of triangle
            mColorHandle = GL.GetUniformLocation(mProgramHandle, "vColor");
            GL.Uniform4(mColorHandle, 1, mColor);

            // Draw the triangle
            GL.DrawArrays(All.Triangles, 0, 3);

            Window.SwapBuffers();

            // Disable vertex array
            GL.DisableVertexAttribArray(mPositionHandle);
        }
        private static int LoadShader(ShaderType type, string source)
        {
            var shader = GL.CreateShader(type);
            if (shader == 0)
                throw new InvalidOperationException("Unable to create shader:" + type.ToString());

            GL.ShaderSource(shader, 1, new string[] { source }, (int[])null);
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out int compiled);
            if (compiled == 0)
            {
                int length = 0;
                GL.GetShader(shader, ShaderParameter.InfoLogLength, out length);
                if (length > 0)
                    GL.GetShaderInfoLog(shader, length, out length, out string log);
                GL.DeleteShader(shader);

                throw new InvalidOperationException("Unable to compile shader of type : " + type.ToString());
            }
            return shader;
        }

        public static int BuildProgram(string vertexShaderSrc, string fragmentShaderSrc)
        {
            var vertexShader = LoadShader(ShaderType.VertexShader, vertexShaderSrc);
            var fragmentShader = LoadShader(ShaderType.FragmentShader, fragmentShaderSrc);

            var mProgramHandle = GL.CreateProgram();
            if (mProgramHandle == 0)
                throw new InvalidOperationException("Unable to create program");

            GL.AttachShader(mProgramHandle, vertexShader);
            GL.AttachShader(mProgramHandle, fragmentShader);

            return mProgramHandle;
        }

        static void Main(string[] args)
        {
            using (var app = new OpenTKApp() { GLMajor = 2, GLMinor = 0 })
                app.Run(args);
        }
    }
}
