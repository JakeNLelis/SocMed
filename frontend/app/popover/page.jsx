'use client'

import React, {useState, useRef} from 'react'


function popover() {
    const [showPopover, setShowPopover] = useState(false);
    const buttonRef = useRef(null);

    const togglePopover = () => {
        setShowPopover(!showPopover);
    };

    return (
        <div className="min-h-screen bg-gray-900 text-white flex items-center justify-center">
            <button className='bg-gray-900 text-white items-center justify-center border-black  relative' popovertarget="my-popover">Open Popover</button>

            <div popover id="my-popover">Greetings, one and all!</div>
        </div>
    )
}

export default popover