using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ScreenShot1Lib
{
    public static class Statistics
    {
        private static string versionInfo = null;

        public static string VersionVersionInfo
        {
            get
            {
                if (versionInfo == null)
                {
                    versionInfo = string.Format(" v{0}.{1} ({4}Build: {2}.{3})",
                        Version.Major,
                        Version.Minor,
                        Version.Build,
                        Version.Revision,
                        IsDebug() ? "Debug " : string.Empty);
                }
                return versionInfo;
            }
        }

        static Version version;
        public static Version Version
        {
            get
            {
                if (version == null)
                {
                    Type t = typeof(Statistics);
                    version = t.Assembly.GetName().Version;
                }

                return version;
            }
        }

        private static bool IsDebug()
        {
            Type t = typeof(Statistics);
            return t.Assembly.GetCustomAttributes(typeof(DebuggableAttribute), false).Length > 0;
        }
    }
}
