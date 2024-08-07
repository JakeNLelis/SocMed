
import Navbar from "@/components/navbar";
import Post from "@/components/post";

export default function Home() {
  return (
    <main>
      <Navbar/>
      <div className="flex justify-center items-center h-screen">
          <Post />
      </div>    
    </main>
  );
}
