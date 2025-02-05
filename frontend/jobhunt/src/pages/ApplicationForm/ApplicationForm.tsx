import React, { useContext, useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import jobApplicationApi from '../../api/jobApplicationApi';
import Container from '../../components/Container/Container';
import './index.css';
import UserDataContext from '../../components/UserDataMode/UserDataMode';

const ApplicationForm: React.FC = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        mobile: '',
        aboutUser: '',
        resume: null as File | null,
        jobId: '' as string | undefined,
        createdBy: '' as string | null
    });
    const context = useContext(UserDataContext);

    if (!context) {
        throw new Error('Component must be used within a Provider');
    }

    const navigate = useNavigate();

    const { userId, image, title } = context;

    const { jobId } = useParams();

    useEffect(() => {
        setFormData({ ...formData, jobId: jobId, createdBy: userId });
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files) {
            setFormData({ ...formData, resume: e.target.files[0] });
        }
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        jobApplicationApi.createJobApplication(formData).then(data => {
            navigate('/');
        });
    };
    
    return (
        <Container>
            <div className="application-form-wrapper">
                <div className="job_info-wrapper">
                    <img className='job_logo' src={image as string} alt="" />
                    <h2>{title}</h2>
                </div>
                <h3>Dane osobowe:</h3>
                <form className="application-form" onSubmit={handleSubmit}>
                    <label className='label_name'>
                        First Name
                        <input
                            type="text"
                            className='input'
                            name="firstName"
                            value={formData.firstName}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label className='label_lastname'>
                        Last name
                        <input
                            type="text"
                            name="lastName"
                            className='input'
                            value={formData.lastName}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label className='label_email'>
                        E-mail
                        <input
                            type="email"
                            name="email"
                            className='input'
                            value={formData.email}
                            placeholder='example@gmail.com'
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label className='label_mobile'>
                        Mobile
                        <input
                            type="tel"
                            name="mobile"
                            className="input"
                            value={formData.mobile}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label className='label_cv'>
                        CV
                        <input
                            type="file"
                            name="resume"
                            onChange={handleFileChange}
                            required

                            className='input'
                        />
                    </label>
                    <label className='label_coverletter'>
                        Is there something more we should know about you?
                        <textarea
                            className='textarea'
                            name="aboutUser"
                            value={formData.aboutUser}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <button type="submit" className="submit-btn">Submit Application</button>
                </form>

            </div>
        </Container>
    );
};

export default ApplicationForm;