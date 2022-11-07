using System;
namespace Modelos
{
	public class ResponseExec
	{
        public bool error { get; set; }
        public string mensaje { get; set; }

        public ResponseExec()
        {
            error = false;
        }
    }
}

