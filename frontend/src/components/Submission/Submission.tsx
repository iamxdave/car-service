import React from 'react'
import Introduction from './Introduction'
import OrderSelection from './OrderSelection'

const Submission = () => {
  return (
    <div className='container my-12 mx-auto md:px-6'>
        <Introduction />
        <OrderSelection />
    </div>
  )
}

export default Submission