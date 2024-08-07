import React from 'react'

function Navbar() {
  return (
    <nav class="bg-background p-4 shadow-md">
        <div class="container mx-auto flex justify-between items-center">
            <div class="text-2xl font-bold text-primary">Brand</div>
            <div class="space-x-4">
                <a href="#" class="text-muted-foreground hover:text-primary">Home</a>
                <a href="#" class="text-muted-foreground hover:text-primary">About</a>
                <a href="#" class="text-muted-foreground hover:text-primary">Services</a>
                <a href="#" class="text-muted-foreground hover:text-primary">Contact</a>
            </div>
        <div>
            <button class="bg-secondary text-secondary-foreground hover:bg-secondary/80 p-2 rounded">Login</button>
        </div>
  </div>
</nav>
  )
}

export default Navbar