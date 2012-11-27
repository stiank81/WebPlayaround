
require './fizzbuzz'

describe FizzBuzz, "output" do
  it "Non fizzbuzz numbers should output themselves" do
    fb = FizzBuzz.new(1)
    fb.output.should eq(1)
  end
end
