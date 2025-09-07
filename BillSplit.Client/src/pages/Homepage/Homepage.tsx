import { Link } from "react-router-dom";

export function Homepage() {
    return (
        <div>
            <div className="mx-auto max-w-screen-xl px-6 lg:px-8 relative">
                <div className="relative flex h-16 space-x-10 w-full">
                    <div className="flex justify-start"><a className="flex flex-shrink-0 items-center" href="/">
                        <img className="block h-8 w-auto" height="32"
                             src="https://www.svgrepo.com/show/303650/neo-logo.svg"/>
                    </a>
                    </div>
                    <div
                        className="flex-shrink-0 flex px-2 py-3 items-center space-x-8 flex-1 justify-end justify-self-end ">
                        <Link to="/auth/login">
                        <a
                            className="text-gray-700 hover:text-lime-700 text-sm font-medium" >Login</a>
                        </Link>
                        <Link to="/auth/register">
                        <a className="text-white bg-gray-800 hover:bg-gray-900 inline-flex items-center justify-center px-3 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm "
                           >Sign up</a>
                        </Link>
                    </div>
                </div>
            </div>
            <div className="max-w-7xl mx-auto relative">
                <div className="relative py-16 flex justify-center px-4 sm:px-0">
                    <div className="max-w-3xl text-center">
                        <div className="pb-4">
                            <span
                                className="inline-flex items-center rounded-2xl bg-lime-100 px-4 py-1.5 text-xs sm:text-sm font-serif font-medium text-lime-700">Having Problem with Splitting Bills</span>
                        </div>
                        <h1 className="text-4xl sm:text-5xl font-semibold text-gray-900 xl:text-6xl font-serif !leading-tight">
                            Discover the future of splitting Bills
                        </h1>
                        <p className="mt-4 text-lg sm:text-xl leading-8 text-gray-800 sm:px-16"
                          >It's really simple. You just hit sign up and start split. Easy Right</p>
                        <div className="mt-8 flex w-full space-x-8 justify-center">
                            <Link to="/auth/register">
                                <button
                                    className="inline-flex items-center justify-center px-4 py-2.5 border border-transparent text-sm font-medium rounded-md shadow-sm focus:outline-none ring-2 ring-offset-2 ring-transparent ring-offset-transparent disabled:bg-gray-400 appearance-none text-white bg-lime-600 hover:bg-lime-700 focus:ring-lime-500 focus:ring-offset-white !px-12 !shadow-lg !rounded-full !text-base">
                                    <p>Start now</p>
                                </button>
                            </Link>
                       
                        </div>
                    </div>
                </div>
            </div>
        </div>

    )
}