"use client";
import React, { useState, useRef } from "react";
import Image from "next/image";
import profilePic from "../public/profile.png";

function Post() {
  const [showPopover, setShowPopover] = useState(false);
  const buttonRef = useRef(null);

  const togglePopover = () => {
    setShowPopover(!showPopover);
  };

  return (
    <div className="bg-card p-4 border-b border-slate-50 shadow-md w-full max-w-md">
      <div className="mt-4">
        <div className="flex items-start justify-between mb-2">
          <div className="flex items-center">
            <Image
              src={profilePic}
              width={100}
              height={100}
              alt="User Avatar"
              className="w-10 h-10 rounded-full mr-3"
            />
            <div>
              <p className="text-primary font-semibold">bhp</p>
              <p className="text-muted-foreground opacity-50 text-sm">20h</p>
            </div>
          </div>
          <div className="relative">
            <button
              ref={buttonRef}
              onClick={togglePopover}
              className="	bg-transparent text-primary-foreground hover:bg-gray-950 w-auto h-auto p-2 rounded-full"
              type="button"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="currentColor"
                className="text-white"
              >
                <circle cx="4" cy="12" r="2" />
                <circle cx="12" cy="12" r="2" />
                <circle cx="20" cy="12" r="2" />
              </svg>
            </button>
            {showPopover && (
              <div
                className="absolute w-auto h-10 p-0 z-10 m-0 inline-block text-sm text-gray-500 bg-white border border-gray-200 rounded-lg dark:text-gray-400 dark:border-gray-600 dark:bg-gray-900"
                style={{
                  top:
                    buttonRef.current.offsetTop +
                    buttonRef.current.offsetHeight,
                  left: buttonRef.current.offsetLeft,
                }}
              >
                <button className="p-0 m-0 px-4 py-2 rounded-lg hover:bg-gray-800">
                  Report
                </button>
              </div>
            )}
          </div>
        </div>
        <p className="text-foreground mb-2">Shaken not stirred. Porsche</p>
        <Image
          src="https://placehold.co/600x400.png?text=Car+Image"
          width={400}
          height={600}
          alt="Porsche Car"
          className="rounded-lg mb-2"
        />
      </div>
      <div className="flex items-center">
        <button className="bg-secondary flex gap-1 text-secondary-foreground hover:bg-secondary/80 p-1 rounded">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
            className="text-white"
          >
            <path d="M12 21C12 21 6 16.5 3 12C-1 6.5 3.5 2 7.5 2C10 2 12 4.5 12 4.5C12 4.5 14 2 16.5 2C20.5 2 25 6.5 21 12C18 16.5 12 21 12 21Z" />
          </svg>
          <span className="text-muted-foreground">39</span>
        </button>
        <button className="bg-secondary flex gap-1 text-secondary-foreground hover:bg-secondary/80 p-1 rounded ml-2">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
            className="text-white"
          >
            <path d="M21 11.5a8.38 8.38 0 0 1-.9 3.8 8.5 8.5 0 0 1-7.6 4.7 8.38 8.38 0 0 1-3.8-.9L3 21l1.9-5.7a8.38 8.38 0 0 1-.9-3.8 8.5 8.5 0 0 1 8.5-8.5 8.5 8.5 0 0 1 8.5 8.5z" />
          </svg>
          <span className="text-muted-foreground">39</span>
        </button>
      </div>
    </div>
  );
}

export default Post;
