const Loader = () => {
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/70">
      <div className="flex space-x-3">
        <span className="h-4 w-4 rounded-full bg-white animate-bounce" />
        <span className="h-4 w-4 rounded-full bg-white animate-bounce [animation-delay:0.15s]" />
        <span className="h-4 w-4 rounded-full bg-white animate-bounce [animation-delay:0.3s]" />
      </div>
    </div>
  );
};

export default Loader;
