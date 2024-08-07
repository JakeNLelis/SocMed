/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
        remotePatterns: [
          {
            protocol: 'https',
            hostname: 'openui.fly.dev',
            port: '',
            pathname: '/**/**/**',
          },
          {
              protocol: "https",
              hostname: "placehold.co",
              port: '',
              pathname: '/**/**',
          }
        ],
      },
};



export default nextConfig;
