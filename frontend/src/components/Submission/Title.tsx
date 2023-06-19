const Title = ({text}:{text:string}) => {
  return (
    <div className="py-4 px-6 md:px-12 mt-12 border-b-4">
        <p className="text-4xl font-normal tracking-wide uppercase">
            {text}
        </p>
    </div>
  )
}

export default Title